using System;
using LogiSpark.Models;
using Unity.VisualScripting;

namespace LogiSpark.Models
{
    public class Source : LogicGate
    {

        public Source(){
            output = true;
        }
        public override bool Evaluate(bool? input1, bool? input2)
        {
            output = true;
            return true;
        }
    }
}