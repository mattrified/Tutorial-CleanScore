using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MattrifiedGames.UIHelper.Demo
{
    public class CleanScoreDemo : MonoBehaviour
    {
        public bool useIntScore;
        public int intScore = 0;
        public float floatScore = 0f;
        public CleanScore cleanScore;

        public int decimalValue = 0;
        public bool autoIncrease;

        // Update is called once per frame
        void Update()
        {
            if (useIntScore)
            {
                if (autoIncrease)
                    intScore += Random.Range(1, 5000);
                SetIntScore();
            }
            else
            {
                if (autoIncrease)
                    floatScore += Random.Range(0f, 5000f);
                SetFloatScore();
            }
        }

        [ContextMenu("Update Float Score")]
        public void SetFloatScore()
        {
            cleanScore.UpdateScoreFromFloat(floatScore, decimalValue);
        }

        [ContextMenu("Update Int Score")]
        public void SetIntScore()
        {
            cleanScore.UpdateScore(intScore);
        }
    }
}