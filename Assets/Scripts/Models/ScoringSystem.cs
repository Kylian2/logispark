using System;

namespace LogiSpark.Models
{
    public abstract class ScoringSystem
    {
        public abstract double ComputeScore(int nbdoors);
        public abstract void Reset();
        public abstract void Start();
        public abstract void Stop();
        public abstract void Pause();
        public abstract bool IsPaused();
        public abstract void Resume();
        public abstract int GetInGameScore();
    }
}