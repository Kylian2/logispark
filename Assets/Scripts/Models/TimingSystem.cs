using System;

namespace LogiSpark.Models
{
    public class TimingSystem : ScoringSystem
    {
        private DateTime? startTime;
        private TimeSpan elapsedTime;
        private bool isPaused = false;

        public override int ComputeScore()
        {
            // Calcule le score final en fonction du temps écoulé
            return (int)GetTotalElapsedTime().TotalSeconds;
        }

        public override void Reset()
        {
            // Réinitialise le chronomètre
            startTime = null;
            elapsedTime = TimeSpan.Zero;
            isPaused = false;
        }

        public override void Start()
        {
            // Démarre ou reprend le chronomètre
            if (startTime == null && !isPaused)
            {
                // Premier démarrage
                startTime = DateTime.Now;
            }
            else if (isPaused)
            {
                // Reprise après pause
                startTime = DateTime.Now;
                isPaused = false;
            }
        }

        public override void Stop()
        {
            // Arrête le chronomètre et accumule le temps
            if (startTime != null && !isPaused)
            {
                AccumulateElapsedTime();
                startTime = null;
            }
        }

        public override void Pause()
        {
            // Met en pause le chronomètre
            if (startTime != null && !isPaused)
            {
                AccumulateElapsedTime();
                startTime = null;
                isPaused = true;
            }
        }

        public override void Resume()
        {
            // Reprend le chronomètre après une pause
            if (isPaused)
            {
                startTime = DateTime.Now;
                isPaused = false;
            }
        }

        public bool IsPaused()
        {
            return isPaused;
        }

        public override int GetInGameScore()
        {
            // Retourne le temps écoulé actuel en secondes
            return (int)GetTotalElapsedTime().TotalSeconds;
        }

        private TimeSpan GetTotalElapsedTime()
        {
            // Calcule le temps total écoulé
            if (startTime != null && !isPaused)
            {
                // Le chronomètre est actif, ajoute le temps courant
                return elapsedTime.Add(DateTime.Now.Subtract(startTime.Value));
            }
            
            // Le chronomètre est arrêté ou en pause, retourne seulement le temps accumulé
            return elapsedTime;
        }

        private void AccumulateElapsedTime()
        {
            // Accumule le temps écoulé depuis le dernier démarrage
            if (startTime != null)
            {
                elapsedTime = elapsedTime.Add(DateTime.Now.Subtract(startTime.Value));
            }
        }
    }
}