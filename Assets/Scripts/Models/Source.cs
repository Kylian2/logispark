using System;
using LogiSpark.Models;

namespace LogiSpark.Models
{
    public class Source : LogicGate
    {
        public override bool Evaluate(bool? input1, bool? input2)
        {
            return true;
        }
    }
}