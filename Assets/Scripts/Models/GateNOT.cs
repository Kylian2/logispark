using System;
using LogiSpark.Models;

namespace LogiSpark.Models
{
    public class GateNOT : LogicGate
    {
        public override bool Evaluate(bool? input1, bool? input2)
        {
            // On utilise la première entrée comme entrée principale pour le NOT
            if (input1 == null)
            {
                throw new ArgumentNullException(nameof(input1), "Input1 cannot be null for a NOT gate.");
            }
            output = !input1.Value;
            return !input1.Value;
        }
    }
}