using System;
using LogiSpark.Models;

namespace LogiSpark.Models
{
    public class GateNAND : LogicGate
    {
        public override bool Evaluate(bool? input1, bool? input2)
        {
            return !(input1.GetValueOrDefault() && input2.GetValueOrDefault());
        }
    }
}