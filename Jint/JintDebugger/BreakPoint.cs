using System;

namespace Jint.JintDebugger {
  public enum StepMode
  {
    Over,
    Into,
    None
  }
  
    public class BreakPoint {
        public int Line { get; set; }
        public int Char { get; set; }
        public string Condition { get; set; }

        public BreakPoint(int line, int character) {
            Line = line;
            Char = character;
        }

        public BreakPoint(int line, int character, string condition)
            : this(line, character) {
            Condition = condition;
        }
    }
}
