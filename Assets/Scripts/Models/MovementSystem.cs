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

        public override double ComputeScore(int nbdoors)
        {
            throw new System.NotImplementedException();
        }

        public override void Reset()
        {
            throw new System.NotImplementedException();
        }

        public override int GetInGameScore()
        {
            return moveCount;
        }


        public override void Pause()
        {
            isCounting = false;
        }

        public override void Resume()
        {
            isCounting = true;
        }
    }
}