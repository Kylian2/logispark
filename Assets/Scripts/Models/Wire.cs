using System;
using UnityEngine;
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
            return input1.GetValueOrDefault();
        }
    }
}