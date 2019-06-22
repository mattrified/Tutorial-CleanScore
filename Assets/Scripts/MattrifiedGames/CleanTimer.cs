using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MattrifiedGames.UIHelper
{
    public class CleanTimer : MonoBehaviour
    {
        public CleanScore minuteScore;
        public CleanScore secondScore;
        public CleanScore millisecondScore;

        TimeSpan timeSpan;

        public void UpdateTime(float seconds)
        {
            timeSpan = TimeSpan.FromSeconds(seconds);

            minuteScore.UpdateIntScore(timeSpan.Minutes + 60 * timeSpan.Hours);
            secondScore.UpdateIntScore(timeSpan.Seconds);
            millisecondScore.UpdateIntScore(timeSpan.Milliseconds);
        }
    }
}
