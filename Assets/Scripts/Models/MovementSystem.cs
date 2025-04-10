using UnityEngine;

namespace LogiSpark.Models
{
    public class MovementSystem: ScoringSystem
    {
        private int moveCount;
        private bool isCounting;

        public MovementSystem()
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
            return 100 * Mathf.Exp(-moveCount+nbdoors);
        }

        public override void Reset()
        {
            moveCount = 0;
        }

        public override int GetInGameScore()
        {
            return moveCount;
        }


        public override void Pause()
        {
            isCounting = false;
        }

        public override bool IsPaused()
        {
            return !isCounting;
        }

        public override void Resume()
        {
            isCounting = true;
        }
    }
}