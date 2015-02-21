using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using Jint.JintDebugger;
using Jint.Parser;
using Jint.Parser.Ast;
using Jint.Runtime;
using Jint.Runtime.Descriptors;
using Jint.Runtime.Environments;
using Binding = Jint.Runtime.Environments.Binding;

namespace Jint.Editor
{
  public partial class Editor : UserControl
  {
    private readonly List<int> _breakpoints = new List<int>();
    private readonly HashSet<int> _breakpointsLineId = new HashSet<int>();
    private readonly Style _commentStyle = new TextStyle(Brushes.Green, null, FontStyle.Regular);
    private readonly Style _functionsStyle = new TextStyle(Brushes.DarkBlue, null, FontStyle.Bold);
    private readonly Style _keywordsStyle = new TextStyle(Brushes.DarkBlue, null, FontStyle.Regular);
    private readonly Style _numberStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
    private readonly Style _textStyle = new TextStyle(Brushes.DarkRed, null, FontStyle.Regular);
    internal int CurrentExecutionLine = -1;
    private Engine _engine;
    private EEngineFlow _engineFlow = EEngineFlow.Stopped;
    private EEngineStatus _engineStatus = EEngineStatus.Stop;

    public Editor()
    {
      InitializeComponent();
    }

    // Key: Line.UniqueId

    private void EditorLoad(object sender, EventArgs e)
    {
      txtScript.Language = Language.JS;
      txtScript.KeyUp += TxtScriptKeyUp;
      txtScript.TextChanged += TxtScriptTextChanged;
      txtScript.PaintLine += TxtScriptPaintLine;
      txtScript.LineRemoved += TxtScriptLineRemoved;

      txtScript.AddStyle(_keywordsStyle);
      txtScript.AddStyle(_functionsStyle);
      txtScript.AddStyle(_commentStyle);
      txtScript.AddStyle(_textStyle);
      txtScript.AddStyle(_numberStyle);

      txtScript.DefaultStyle.ForeBrush = Brushes.Black;

      SetUpEngine();
    }

    private void SetUpEngine()
    {
      if (_engine != null)
      {
        _engine.Step -= EngineStep;
        _engine.TestBreakExecution -= EngineTestBreakExecution;
      }

      Assembly[] assems =
      {
        typeof (MessageBox).Assembly
        , typeof (Point).Assembly
      };
      _engine = new Engine(cfg => cfg.AllowClr(assems));
      //engine.AllowClr = true;
      //engine.DisableSecurity();

      _engine.Step += EngineStep;
      _engine.TestBreakExecution += EngineTestBreakExecution;

      _engine.SetValue("alert",
        new Func<string, DialogResult>(
          o => MessageBox.Show(o, "Script Alert", MessageBoxButtons.OK,
            MessageBoxIcon.Information)));

      _engine.SetValue("print", new Action<string>(OutputText));

      _engine.SetValue("assert", new Func<object, object, bool>((o1, o2) =>
      {
        string currentLine = (CurrentExecutionLine + 1).ToString(CultureInfo.InvariantCulture);

        if ((o1 == null && o2 == null))
        {
          OutputText("Jint Assert succeed at line " + currentLine);
          return true;
        }

        if (o1 != null)
        {
          if (o1.Equals(o2))
          {
            OutputText("Jint Assert succeed at line " + currentLine);
            return true;
          }
        }

        OutputText("Jint Assert failed at line " + currentLine);

        return false;
      }));

      _engine.SetValue("debugger", new Action(() =>
      {
        if (_engineFlow == EEngineFlow.Breakpointing || _engineFlow == EEngineFlow.Stepping)
        {
          _engineStatus = EEngineStatus.Step;
        }
      }));
    }

    private bool EngineTestBreakExecution(bool ignoreBreak)
    {
      if (ignoreBreak)
      {
        return false;
      }

      if (_engine.DebugMode)
      {
        Application.DoEvents();
        if (_engineStatus == EEngineStatus.BreakExecution
            || _engineStatus == EEngineStatus.Stop)
        {
          _engineStatus = EEngineStatus.Stop;
          return true;
        }
      }
      return false;
    }

    private void OutputText(string msg)
    {
      txtOutput.AppendText(msg + Environment.NewLine);
    }

    private void TxtScriptLineRemoved(object sender, LineRemovedEventArgs e)
    {
      //remove lines from breakpoints
      foreach (int id in e.RemovedLineUniqueIds)
        if (_breakpointsLineId.Contains(id))
        {
          _breakpointsLineId.Remove(id);
          _breakpoints.Remove(id);
        }
    }

    private void TxtScriptPaintLine(object sender, PaintLineEventArgs e)
    {
      if (_breakpointsLineId.Contains(txtScript[e.LineIndex].UniqueId))
      {
        e.Graphics.FillEllipse(
          new LinearGradientBrush(new Rectangle(0, e.LineRect.Top, 15, 15), Color.Pink, Color.DarkRed, 45), 0,
          e.LineRect.Top, 15, 15);
        e.Graphics.DrawEllipse(Pens.DarkRed, 0, e.LineRect.Top, 15, 15);
      }
    }

    private void TxtScriptTextChanged(object sender, TextChangedEventArgs e)
    {
      //clear style of changed range
      e.ChangedRange.ClearStyle(_commentStyle);
      e.ChangedRange.ClearStyle(_keywordsStyle);
      e.ChangedRange.ClearStyle(_functionsStyle);

      //comment highlighting
      e.ChangedRange.SetStyle(_commentStyle, @"//.*$", RegexOptions.Multiline);
      e.ChangedRange.SetStyle(_keywordsStyle,
        @"\b(alert|write|break|continue|do|for|import|new|this|void|case|default|else|function|in|return|typeof|while|comment|delete|export|if|label|switch|var|with)\b");
      e.ChangedRange.SetStyle(_functionsStyle, @"\b(App|Model)\b");
      e.ChangedRange.SetStyle(_textStyle, @""".*""");
      e.ChangedRange.SetStyle(_numberStyle, @"[0-9]+(.[0-9]+)?");

      //clear folding markers of changed range
      e.ChangedRange.ClearFoldingMarkers();
      //set folding markers
      e.ChangedRange.SetFoldingMarkers("{", "}");
    }

    private void TxtScriptKeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.F5)
      {
        Run();
        e.Handled = true;
      }
    }

    private void BtnNewClick(object sender, EventArgs e)
    {
      txtScript.Text = "";
      ClearWindows();
    }

    private void BtnLoadClick(object sender, EventArgs e)
    {
      var fod = new OpenFileDialog
      {
        AddExtension = true,
        AutoUpgradeEnabled = true,
        CheckFileExists = true,
        DefaultExt = "js",
        Filter = "JavaScript|*.js|All Files (*.*)|*.*",
        Multiselect = false,
        Title = "Open JavaScript File"
      };
      if (fod.ShowDialog() == DialogResult.OK)
      {
        txtScript.Text = File.ReadAllText(fod.FileName);
        ClearWindows();
      }
    }

    private void BtnSaveClick(object sender, EventArgs e)
    {
      var fsd = new SaveFileDialog
      {
        AddExtension = true,
        AutoUpgradeEnabled = true,
        DefaultExt = "js",
        Filter = "JavaScript|*.js|All Files (*.*)|*.*",
        OverwritePrompt = true,
        Title = "Save JavaScript File"
      };
      if (fsd.ShowDialog() == DialogResult.OK)
      {
        File.WriteAllText(fsd.FileName, txtScript.Text);
      }
    }

    private void BtnRunClick(object sender, EventArgs e)
    {
      _engine.DebugMode = false;
      _engineStatus = EEngineStatus.Run;
      _engineFlow = EEngineFlow.Running;
      Run();
    }

    private void BtnDebugClick(object sender, EventArgs e)
    {
      if (_engineFlow == EEngineFlow.Stopped)
      {
        _engine.DebugMode = true;
        _engineFlow = EEngineFlow.Breakpointing;
        _engineStatus = EEngineStatus.Breakpoint;
        Run();
      }
      else
      {
        _engineFlow = EEngineFlow.Breakpointing;
        _engineStatus = EEngineStatus.Continue;
      }
    }

    private void BtnStepInClick(object sender, EventArgs e)
    {
      if (_engineFlow == EEngineFlow.Stopped)
      {
        _engineStatus = EEngineStatus.Step;
        _engineFlow = EEngineFlow.Stepping;
        _engine._stepMode = StepMode.Into;
        Run();
      }
      else
      {
        _engineStatus = EEngineStatus.Continue;
        _engineFlow = EEngineFlow.Stepping;
        _engine._stepMode = StepMode.Into;
      }
    }

    private void BtnStepOverClick(object sender, EventArgs e)
    {
      if (_engineFlow == EEngineFlow.Stopped)
      {
        _engineStatus = EEngineStatus.Step;
        _engineFlow = EEngineFlow.Stepping;
        _engine._stepMode = StepMode.Into;
        Run();
      }
      else
      {
        _engineStatus = EEngineStatus.ContinueOver;
        _engineFlow = EEngineFlow.Stepping;
        _engine._stepMode = StepMode.Over;
      }
    }

    private void BtnStopClick(object sender, EventArgs e)
    {
      _engineStatus = EEngineStatus.Stop;
      _engineFlow = EEngineFlow.Stopped;
      SetUpEngine();
    }

    private void TsbToggleBreakpointClick(object sender, EventArgs e)
    {
      int id = txtScript[txtScript.Selection.Start.iLine].UniqueId;
      if (_breakpointsLineId.Contains(id))
      {
        //remove Breakpoint
        _breakpoints.Remove(id);
        _breakpointsLineId.Remove(id);
      }
      else
      {
        //add Breakpoint
        _breakpoints.Add(id);
        _breakpointsLineId.Add(id);
      }

      SetupBreakpoints();

      //repaint
      txtScript.Invalidate();
    }

    private void TsbClearBreakpointsClick(object sender, EventArgs e)
    {
      _breakpoints.Clear();
      _breakpointsLineId.Clear();
      SetupBreakpoints();
      txtScript.Invalidate();
    }

    private void SetupBreakpoints()
    {
      _engine.BreakPoints.Clear();
      for (int i = 0; i < _breakpoints.Count; i++)
      {
        Line line = txtScript[_breakpoints[i]];

        _engine.BreakPoints.Add(new BreakPoint(_breakpoints[i] + 1, line.Count/2));
      }
    }

    private void TsbClearOutputClick(object sender, EventArgs e)
    {
      txtOutput.Text = "";
    }

    private void ClearWindows()
    {
      txtVariables.Text = "";
      txtOutput.Text = "";
      txtStack.Text = "";
    }

    private void Run()
    {
      try
      {
        ClearWindows();
        Range currentSel = txtScript.Selection;
        var options = new ParserOptions();

        string src = txtScript.SelectedText != "" ? txtScript.SelectedText : txtScript.Text;
        options.Source = src;
        _engine.Execute(src, options);
        CurrentExecutionLine = -1;
        _engineFlow = EEngineFlow.Stopped;
        txtScript.Selection = currentSel;
        txtScript.DoSelectionVisible();
        txtScript.Invalidate();
      }
      catch (JavaScriptException je)
      {
        if (_engine.CurrentStatement != null)
        {
          int curLine = _engine.CurrentStatement.Location.Start.Line;
          OutputText(string.Format("{0}: {1}", curLine, je));
        }
        else
        {
          OutputText(string.Format("{0}", je));
        }
      }
      catch (Exception ex)
      {
        if (!ex.Message.Contains("StopEngineException"))
        {
          if (_engine.CurrentStatement != null)
          {
            int curLine = _engine.CurrentStatement.Location.Start.Line;
            OutputText(string.Format("{0}: {1}", curLine, ex.Message));
          }
          else
          {
            OutputText(string.Format("{0}", ex.Message));
          }
        }
        _engineStatus = EEngineStatus.Stop;
        _engineFlow = EEngineFlow.Stopped;
        SetUpEngine();
      }
    }

    private StepMode EngineStep(object sender, DebugInformation e)
    {
      var stepMode = StepMode.Into;
      CurrentExecutionLine = e.CurrentStatement.Location.Start.Line - 1;
      txtScript.Selection.Start = new Place(0, CurrentExecutionLine);
      txtScript.Selection.End = new Place(txtScript[CurrentExecutionLine].Count, CurrentExecutionLine);
      txtScript.DoSelectionVisible();
      txtScript.Invalidate();

      ShowStack(e.CallStack, e);
      ShowLocals(e.Locals);
      Application.DoEvents();

      while (
        (_engineStatus == EEngineStatus.Step && (e.CurrentStatement is FunctionDeclaration == false))
        || (_engineStatus == EEngineStatus.Breakpoint && _breakpoints.Contains(CurrentExecutionLine))
        )
      {
        Application.DoEvents();
      }

      if (_engineStatus == EEngineStatus.Continue || _engineStatus == EEngineStatus.ContinueOver)
      {
        if (_engineFlow == EEngineFlow.Stepping)
        {
          if (_engineStatus == EEngineStatus.Continue)
          {
            stepMode = StepMode.Into;
          }
          if (_engineStatus == EEngineStatus.ContinueOver)
          {
            stepMode = StepMode.Over;
          }
          _engineStatus = EEngineStatus.Step;
        }
        else if (_engineFlow == EEngineFlow.Breakpointing)
        {
          _engineStatus = EEngineStatus.Breakpoint;
        }
      }

      if (_engineStatus == EEngineStatus.Stop)
        throw new StopEngineException();

      return stepMode;
    }

    private void ShowLocals(EnvironmentRecord locals)
    {
      var sb = new StringBuilder();
      if (locals != null && locals.Bindings != null)
      {
        foreach (KeyValuePair<string, Binding> vd in locals.Bindings)
        {
          if (vd.Value != null)
          {
            sb.AppendLine(vd.Key + ": " + vd.Value.Value);
          }
          else
          {
            sb.AppendLine(vd.Key + ": null");
          }
        }
      }
      else
      {
        sb.AppendLine("No local scope");
      }
      foreach (KeyValuePair<string, PropertyDescriptor> n in locals.Engine.Global.Properties)
      {
        string type = n.Value.Value.Value.Type.ToString();
          if (n.Value.Value == null || !n.Value.Value.Value.IsObject() ||
              n.Value.Value.Value.AsObject().Class != "Function")
          {
            if (n.Value != null)
            {
              sb.AppendLine(string.Format("{0}({1}): {2}", n.Key, type, n.Value.Value.Value));
            }
        }

      } 
      
      txtVariables.Text = sb.ToString();
    }

    private void ShowStack(Stack<string> stack, DebugInformation e)
    {
      var sb = new StringBuilder();
      var stmt = e.CurrentStatement.Location.Source.Replace("\n", " ");
      stmt = stmt.Replace("\r", " ");
      stmt = stmt.Substring(e.CurrentStatement.Range[0], e.CurrentStatement.Range[1] - e.CurrentStatement.Range[0]);
      sb.AppendLine(string.Format("PC: {0}-{1}: {2}",
        e.CurrentStatement.Location.Start.Line + 1,
        e.CurrentStatement.Location.End.Line + 1,
        (stmt.Length > 40 ? stmt.Substring(0, 40) + "..." : stmt)));

      sb.AppendLine("----call stack----");
      foreach (string t in stack)
      {
        sb.AppendLine(t);
      }
      txtStack.Text = sb.ToString();
    }


    private enum EEngineFlow
    {
      Stopped,
      Running,
      Stepping,
      Breakpointing
    }

    private enum EEngineStatus
    {
      Run,
      Stop,
      Step,
      Continue,
      Breakpoint,
      BreakExecution,
      ContinueOver
    }

    private class StopEngineException : Exception
    {
    }
  }
}