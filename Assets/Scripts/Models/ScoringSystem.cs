using System;

namespace LogiSpark.Models
{
    public abstract class ScoringSystem
    {
        // Method to compute the score
        public abstract int ComputeScore();

        // Method to reset the scoring system
        public abstract void Reset();

        // Method to start the scoring system
        public abstract void Start();

        // Method to stop the scoring system
        public abstract void Stop();
        public abstract void Pause();
        public abstract void Resume();
        public abstract int GetInGameScore();
    }
}