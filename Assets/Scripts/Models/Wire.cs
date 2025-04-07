using System;
using LogiSpark.Models;

namespace LogiSpark.Models
{
    public class Wire : LogicGate
    {
        public override bool Evaluate(bool? input1, bool? input2)
        {
            if(input1 == null)
            {
                throw new ArgumentNullException("Signal value cannot be null");
            }
            output = input1.GetValueOrDefault();
            return output;
        }
    }
}