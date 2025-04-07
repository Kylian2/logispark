using System;

namespace LogiSpark.Models
{
    public abstract class LogicGate
    {
        private bool unchanging;
        protected bool output;
        public abstract bool Evaluate(bool? signal1, bool? signal2);

        public bool ?GetOutput()
        {
            return this.output;
        }
    }
}