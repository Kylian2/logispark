using System;

namespace LogiSpark.Models
{
    public class GateAND : LogicGate
    {
        public override bool Evaluate(bool? signal1, bool? signal2)
        {
            return signal1.GetValueOrDefault() && signal2.GetValueOrDefault();
        }
    }
}
