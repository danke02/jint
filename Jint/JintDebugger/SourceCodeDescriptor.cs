using System;
using Jint.Parser;

namespace Jint.JintDebugger
{

  public enum ParameterKindEnum
  {
    Constant,
    EnumKind,
    Expression,
    Server,
    Client,
    FileName,
    UnKnown,
    ScriptParam,
    SimFileName,
    ServerSimColumnName,
    CleintSimColumnName,
    SessionPath,
    SectorPath,
    FlowChartVariable,
    ScriptFunction,
    ClientSboControlTagName61850,
    ServerSboControlTagName61850,
    ServerSboSelectTagName61850,
    DTMDevicePath,
    DTMNodePath,
    Object,
    ExpressionBool,
    ExpressionEnum
  }

  public class ParameterDescription
  {
    public ParameterDescription(string descripParam, ParameterKindEnum kind)
    {
      Description = descripParam;
      Kind = kind;
      EnumType = null;
    }

    public ParameterDescription(string descripParam, ParameterKindEnum kind, Type type)
    {
      Description = descripParam;
      Kind = kind;
      EnumType = type;
    }

    public string Description { get; set; }

    public ParameterKindEnum Kind { get; set; }

    public Type EnumType { get; set; }


  }

  public class ReturnValueDescription
  {
    public ReturnValueDescription(string descripParam)
    {
      Description = descripParam;
    }

    public string Description { get; private set; }
  }

  public class SourceCodeDescriptor
  {
    protected Position MyStart;

    protected Position MyStop;

    public SourceCodeDescriptor(int startLine, int startChar, int stopLine, int stopChar, string code)
    {
      Code = code;

      Start = new Position {Line = startLine, Column = startChar};
      Stop = new Position {Line = stopLine, Column = stopChar};
    }

    public Position Start
    {
      get { return MyStart; }
      set { MyStart = value; }
    }

    public Position Stop
    {
      get { return MyStop; }
      set { MyStop = value; }
    }

    public string Code { get; private set; }

    public override string ToString()
    {
      return "Line: " + Start.Line + " Column: " + Start.Column;
    }

  }
}