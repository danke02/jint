namespace Jint.Editor {
    partial class Editor {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( ) {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.btnNew = new System.Windows.Forms.ToolStripButton();
      this.btnLoad = new System.Windows.Forms.ToolStripButton();
      this.btnSave = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.btnRun = new System.Windows.Forms.ToolStripButton();
      this.btnDebug = new System.Windows.Forms.ToolStripButton();
      this.btnStepIn = new System.Windows.Forms.ToolStripButton();
      this.btnStepOver = new System.Windows.Forms.ToolStripButton();
      this.btnStop = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.btnToggleBreakpoint = new System.Windows.Forms.ToolStripButton();
      this.btnClearBreakpoints = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.btnClearOutput = new System.Windows.Forms.ToolStripButton();
      this.txtScript = new FastColoredTextBoxNS.FastColoredTextBox();
      this.splitContainer = new System.Windows.Forms.SplitContainer();
      this.tabControl = new System.Windows.Forms.TabControl();
      this.tabVariables = new System.Windows.Forms.TabPage();
      this.txtVariables = new System.Windows.Forms.TextBox();
      this.tabStack = new System.Windows.Forms.TabPage();
      this.txtStack = new System.Windows.Forms.TextBox();
      this.tabOutput = new System.Windows.Forms.TabPage();
      this.txtOutput = new System.Windows.Forms.TextBox();
      this.toolStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txtScript)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
      this.splitContainer.Panel1.SuspendLayout();
      this.splitContainer.Panel2.SuspendLayout();
      this.splitContainer.SuspendLayout();
      this.tabControl.SuspendLayout();
      this.tabVariables.SuspendLayout();
      this.tabStack.SuspendLayout();
      this.tabOutput.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStrip1
      // 
      this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnLoad,
            this.btnSave,
            this.toolStripSeparator1,
            this.btnRun,
            this.btnDebug,
            this.btnStepIn,
            this.btnStepOver,
            this.btnStop,
            this.toolStripSeparator2,
            this.btnToggleBreakpoint,
            this.btnClearBreakpoints,
            this.toolStripSeparator3,
            this.btnClearOutput});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(676, 25);
      this.toolStrip1.TabIndex = 0;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // btnNew
      // 
      this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
      this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnNew.Name = "btnNew";
      this.btnNew.Size = new System.Drawing.Size(35, 22);
      this.btnNew.Text = "New";
      this.btnNew.Click += new System.EventHandler(this.BtnNewClick);
      // 
      // btnLoad
      // 
      this.btnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
      this.btnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnLoad.Name = "btnLoad";
      this.btnLoad.Size = new System.Drawing.Size(37, 22);
      this.btnLoad.Text = "Load";
      this.btnLoad.Click += new System.EventHandler(this.BtnLoadClick);
      // 
      // btnSave
      // 
      this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
      this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(35, 22);
      this.btnSave.Text = "Save";
      this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // btnRun
      // 
      this.btnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnRun.Image = ((System.Drawing.Image)(resources.GetObject("btnRun.Image")));
      this.btnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnRun.Name = "btnRun";
      this.btnRun.Size = new System.Drawing.Size(32, 22);
      this.btnRun.Text = "Run";
      this.btnRun.Click += new System.EventHandler(this.BtnRunClick);
      // 
      // btnDebug
      // 
      this.btnDebug.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnDebug.Image = ((System.Drawing.Image)(resources.GetObject("btnDebug.Image")));
      this.btnDebug.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnDebug.Name = "btnDebug";
      this.btnDebug.Size = new System.Drawing.Size(46, 22);
      this.btnDebug.Text = "Debug";
      this.btnDebug.Click += new System.EventHandler(this.BtnDebugClick);
      // 
      // btnStepIn
      // 
      this.btnStepIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnStepIn.Image = ((System.Drawing.Image)(resources.GetObject("btnStepIn.Image")));
      this.btnStepIn.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnStepIn.Name = "btnStepIn";
      this.btnStepIn.Size = new System.Drawing.Size(47, 22);
      this.btnStepIn.Text = "Step In";
      this.btnStepIn.Click += new System.EventHandler(this.BtnStepInClick);
      // 
      // btnStepOver
      // 
      this.btnStepOver.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnStepOver.Image = ((System.Drawing.Image)(resources.GetObject("btnStepOver.Image")));
      this.btnStepOver.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnStepOver.Name = "btnStepOver";
      this.btnStepOver.Size = new System.Drawing.Size(62, 22);
      this.btnStepOver.Text = "Step Over";
      this.btnStepOver.Click += new System.EventHandler(this.BtnStepOverClick);
      // 
      // btnStop
      // 
      this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
      this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnStop.Name = "btnStop";
      this.btnStop.Size = new System.Drawing.Size(35, 22);
      this.btnStop.Text = "Stop";
      this.btnStop.Click += new System.EventHandler(this.BtnStopClick);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
      // 
      // btnToggleBreakpoint
      // 
      this.btnToggleBreakpoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnToggleBreakpoint.Image = ((System.Drawing.Image)(resources.GetObject("btnToggleBreakpoint.Image")));
      this.btnToggleBreakpoint.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnToggleBreakpoint.Name = "btnToggleBreakpoint";
      this.btnToggleBreakpoint.Size = new System.Drawing.Size(108, 22);
      this.btnToggleBreakpoint.Text = "Toggle Breakpoint";
      this.btnToggleBreakpoint.Click += new System.EventHandler(this.TsbToggleBreakpointClick);
      // 
      // btnClearBreakpoints
      // 
      this.btnClearBreakpoints.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnClearBreakpoints.Image = ((System.Drawing.Image)(resources.GetObject("btnClearBreakpoints.Image")));
      this.btnClearBreakpoints.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnClearBreakpoints.Name = "btnClearBreakpoints";
      this.btnClearBreakpoints.Size = new System.Drawing.Size(103, 22);
      this.btnClearBreakpoints.Text = "Clear Breakpoints";
      this.btnClearBreakpoints.Click += new System.EventHandler(this.TsbClearBreakpointsClick);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
      // 
      // btnClearOutput
      // 
      this.btnClearOutput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnClearOutput.Image = ((System.Drawing.Image)(resources.GetObject("btnClearOutput.Image")));
      this.btnClearOutput.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnClearOutput.Name = "btnClearOutput";
      this.btnClearOutput.Size = new System.Drawing.Size(79, 22);
      this.btnClearOutput.Text = "Clear Output";
      this.btnClearOutput.Click += new System.EventHandler(this.TsbClearOutputClick);
      // 
      // txtScript
      // 
      this.txtScript.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
      this.txtScript.AutoScrollMinSize = new System.Drawing.Size(44, 14);
      this.txtScript.BackBrush = null;
      this.txtScript.CharHeight = 14;
      this.txtScript.CharWidth = 8;
      this.txtScript.Cursor = System.Windows.Forms.Cursors.IBeam;
      this.txtScript.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
      this.txtScript.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtScript.IsReplaceMode = false;
      this.txtScript.LeftBracket = '{';
      this.txtScript.LeftBracket2 = '(';
      this.txtScript.LeftPadding = 17;
      this.txtScript.Location = new System.Drawing.Point(0, 0);
      this.txtScript.Name = "txtScript";
      this.txtScript.Paddings = new System.Windows.Forms.Padding(0);
      this.txtScript.RightBracket = '}';
      this.txtScript.RightBracket2 = ')';
      this.txtScript.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
      this.txtScript.Size = new System.Drawing.Size(676, 321);
      this.txtScript.TabIndex = 1;
      this.txtScript.Zoom = 100;
      // 
      // splitContainer
      // 
      this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.splitContainer.Location = new System.Drawing.Point(0, 25);
      this.splitContainer.Name = "splitContainer";
      this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer.Panel1
      // 
      this.splitContainer.Panel1.Controls.Add(this.txtScript);
      // 
      // splitContainer.Panel2
      // 
      this.splitContainer.Panel2.Controls.Add(this.tabControl);
      this.splitContainer.Size = new System.Drawing.Size(676, 557);
      this.splitContainer.SplitterDistance = 321;
      this.splitContainer.TabIndex = 2;
      // 
      // tabControl
      // 
      this.tabControl.Controls.Add(this.tabVariables);
      this.tabControl.Controls.Add(this.tabStack);
      this.tabControl.Controls.Add(this.tabOutput);
      this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl.Location = new System.Drawing.Point(0, 0);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new System.Drawing.Size(676, 232);
      this.tabControl.TabIndex = 0;
      // 
      // tabVariables
      // 
      this.tabVariables.Controls.Add(this.txtVariables);
      this.tabVariables.Location = new System.Drawing.Point(4, 22);
      this.tabVariables.Name = "tabVariables";
      this.tabVariables.Padding = new System.Windows.Forms.Padding(3);
      this.tabVariables.Size = new System.Drawing.Size(668, 206);
      this.tabVariables.TabIndex = 0;
      this.tabVariables.Text = "Locals";
      this.tabVariables.UseVisualStyleBackColor = true;
      // 
      // txtVariables
      // 
      this.txtVariables.AcceptsReturn = true;
      this.txtVariables.BackColor = System.Drawing.SystemColors.Window;
      this.txtVariables.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtVariables.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtVariables.HideSelection = false;
      this.txtVariables.Location = new System.Drawing.Point(3, 3);
      this.txtVariables.Multiline = true;
      this.txtVariables.Name = "txtVariables";
      this.txtVariables.ReadOnly = true;
      this.txtVariables.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txtVariables.Size = new System.Drawing.Size(662, 200);
      this.txtVariables.TabIndex = 0;
      this.txtVariables.WordWrap = false;
      // 
      // tabStack
      // 
      this.tabStack.Controls.Add(this.txtStack);
      this.tabStack.Location = new System.Drawing.Point(4, 22);
      this.tabStack.Name = "tabStack";
      this.tabStack.Padding = new System.Windows.Forms.Padding(3);
      this.tabStack.Size = new System.Drawing.Size(668, 206);
      this.tabStack.TabIndex = 1;
      this.tabStack.Text = "Stack";
      this.tabStack.UseVisualStyleBackColor = true;
      // 
      // txtStack
      // 
      this.txtStack.BackColor = System.Drawing.SystemColors.Window;
      this.txtStack.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtStack.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtStack.HideSelection = false;
      this.txtStack.Location = new System.Drawing.Point(3, 3);
      this.txtStack.Multiline = true;
      this.txtStack.Name = "txtStack";
      this.txtStack.ReadOnly = true;
      this.txtStack.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txtStack.Size = new System.Drawing.Size(662, 200);
      this.txtStack.TabIndex = 0;
      this.txtStack.WordWrap = false;
      // 
      // tabOutput
      // 
      this.tabOutput.Controls.Add(this.txtOutput);
      this.tabOutput.Location = new System.Drawing.Point(4, 22);
      this.tabOutput.Name = "tabOutput";
      this.tabOutput.Padding = new System.Windows.Forms.Padding(3);
      this.tabOutput.Size = new System.Drawing.Size(668, 206);
      this.tabOutput.TabIndex = 2;
      this.tabOutput.Text = "Output";
      this.tabOutput.UseVisualStyleBackColor = true;
      // 
      // txtOutput
      // 
      this.txtOutput.BackColor = System.Drawing.SystemColors.Window;
      this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtOutput.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtOutput.HideSelection = false;
      this.txtOutput.Location = new System.Drawing.Point(3, 3);
      this.txtOutput.Multiline = true;
      this.txtOutput.Name = "txtOutput";
      this.txtOutput.ReadOnly = true;
      this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txtOutput.Size = new System.Drawing.Size(662, 200);
      this.txtOutput.TabIndex = 1;
      this.txtOutput.WordWrap = false;
      // 
      // Editor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitContainer);
      this.Controls.Add(this.toolStrip1);
      this.Name = "Editor";
      this.Size = new System.Drawing.Size(676, 582);
      this.Load += new System.EventHandler(this.EditorLoad);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txtScript)).EndInit();
      this.splitContainer.Panel1.ResumeLayout(false);
      this.splitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
      this.splitContainer.ResumeLayout(false);
      this.tabControl.ResumeLayout(false);
      this.tabVariables.ResumeLayout(false);
      this.tabVariables.PerformLayout();
      this.tabStack.ResumeLayout(false);
      this.tabStack.PerformLayout();
      this.tabOutput.ResumeLayout(false);
      this.tabOutput.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private FastColoredTextBoxNS.FastColoredTextBox txtScript;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabVariables;
        private System.Windows.Forms.TabPage tabStack;
        private System.Windows.Forms.TextBox txtVariables;
        private System.Windows.Forms.TextBox txtStack;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TabPage tabOutput;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnLoad;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnRun;
        private System.Windows.Forms.ToolStripButton btnDebug;
        private System.Windows.Forms.ToolStripButton btnStepIn;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnToggleBreakpoint;
        private System.Windows.Forms.ToolStripButton btnClearBreakpoints;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnClearOutput;
        private System.Windows.Forms.ToolStripButton btnStepOver;
    }
}
