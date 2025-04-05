using System;
using LogiSpark.Models;

namespace Models
{
    public class GateOR : LogicGate
    {
        public override bool Evaluate(bool? input1, bool? input2)
        {
            return input1.GetValueOrDefault() || input2.GetValueOrDefault();
        }
    }
}