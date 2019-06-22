using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MattrifiedGames.UIHelper.Demo
{
    /// <summary>
    /// Demo for updating the score every frame.
    /// </summary>
    public class CleanScoreDemo : MonoBehaviour
    {
        [Tooltip("If true, the score will be updated based on the integer value.")]
        public bool useIntScore;

        [Tooltip("The integer score value.")]
        public int intScore = 0;

        [Tooltip("The float score value.")]
        public float floatScore = 0f;

        [Tooltip("The Clean Score Component reference.")]
        public CleanScoreBase cleanScore;

        [Tooltip("If the float score is being displayed, how many decimal places are shown.")]
        public int decimalValue = 0;

        [Tooltip("If true, the score will automatically update every frame by a random value.")]
        public bool autoIncrease;

        [Tooltip("If true, the \"clean\" score and string based score will update.")]
        public bool updateString;
        public bool UpdateString { get { return updateString; } set { updateString = value; } }

        [Tooltip("Reference to the text mesh pro object that displayst the string based score value.")]
        public TextMeshProUGUI textMeshProString;

        // Update is called once per frame
        void Update()
        {
            if (useIntScore)
            {
                if (autoIncrease)
                    intScore += Random.Range(1, 5000);
                SetIntScore();

                if (updateString)
                    textMeshProString.text = intScore.ToString();
            }
            else
            {
                if (autoIncrease)
                    floatScore += Random.Range(0f, 5000f);
                SetFloatScore();

                if (updateString)
                    textMeshProString.text = floatScore.ToString();
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