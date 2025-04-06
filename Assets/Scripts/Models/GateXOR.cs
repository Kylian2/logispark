using System;
using LogiSpark.Models;

namespace LogiSpark.Models
{
    public class GateXOR : LogicGate
    {
        public override bool Evaluate(bool? input1, bool? input2)
        {
            return (input1.GetValueOrDefault() || input2.GetValueOrDefault()) && !(input1.GetValueOrDefault() && input2.GetValueOrDefault());
        }
    }
}