using System;

namespace LogiSpark.Models
{
    public abstract class LogicGate
    {
        private bool unchanging;
        private bool output;
        public abstract bool Evaluate(bool? signal1, bool? signal2);
    }
}