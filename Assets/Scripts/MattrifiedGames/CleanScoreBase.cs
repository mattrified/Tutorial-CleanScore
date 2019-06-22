using UnityEngine;

namespace MattrifiedGames.UIHelper
{
    /// <summary>
    /// Made an abstract class so it can be expanded upon for different types of scoring requirements.
    /// </summary>
    public abstract class CleanScoreBase : MonoBehaviour
    {
        public void UpdateIntScore(int score)
        {
            UpdateScore(score, 0);
        }

        public void UpdateScoreFromFloat(float score, int decimalValue = 0)
        {
            // Rounds the score to an integer
            long lScore = (long)Mathf.Floor(score * Mathf.Pow(10, decimalValue));
            UpdateScore(lScore, decimalValue);
        }

        public abstract void UpdateScore(long lScore, int decimalValue = 0);
    }
}
