using UnityEngine;

namespace LogiSpark.Models
{
    public class MovementCounter: ScoringSystem
    {
        private int moveCount;
        private bool isCounting;

        public MovementCounter()
        {
            moveCount = 0;
            isCounting = false;
        }

        public override void Start()
        {
            isCounting = true;
            moveCount = 0;
        }

        public override void Stop()
        {
            isCounting = false;
        }

        public void RegisterMove()
        {
            if (isCounting)
            {
                moveCount++;
            }
        }

        public int GetMoveCount()
        {
            return moveCount;
        }

        public override int ComputeScore()
        {
            throw new System.NotImplementedException();
        }

        public override void Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}