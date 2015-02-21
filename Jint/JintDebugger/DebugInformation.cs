using System;
using System.Collections.Generic;
using Jint.Parser.Ast;
using Jint.Runtime.CallStack;
using Jint.Runtime.Environments;

namespace Jint.JintDebugger {
    public class DebugInformation : EventArgs {
        public Stack<String> CallStack { get; set; }
        public Statement CurrentStatement { get; set; }
        public EnvironmentRecord Locals { get; set; }
    }
}
