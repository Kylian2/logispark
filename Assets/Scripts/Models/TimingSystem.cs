using System;

namespace LogiSpark.Models
{
    public class TimingSystem: ScoringSystem
    {
        private DateTime? startTime;
        private TimeSpan elapsedTime;

        public TimeSpan ElapsedTime => elapsedTime;

        public override int ComputeScore()
        {
            throw new NotImplementedException();
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }

        public override void Start()
        {
            if (startTime == null)
            {
                startTime = DateTime.Now;
            }
        }

        public override void Stop()
        {
            if (startTime != null)
            {
                elapsedTime += DateTime.Now - startTime.Value;
                startTime = null;
            }
        }
    }
}