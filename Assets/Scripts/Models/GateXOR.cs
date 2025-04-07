using System;
using LogiSpark.Models;

namespace LogiSpark.Models
{
    public class GateXOR : LogicGate
    {
        public override bool Evaluate(bool? input1, bool? input2)
        {
            if(input1 == null || input2 == null)
            {
                throw new ArgumentNullException("Signal values cannot be null");
            }
            output = (input1.GetValueOrDefault() || input2.GetValueOrDefault()) && !(input1.GetValueOrDefault() && input2.GetValueOrDefault());
            return output;
        }
    }
}