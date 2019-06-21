using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MattrifiedGames.UIHelper
{
    public class CleanScore : MonoBehaviour
    {
        public const string STR_SPACE = " ";
        public const string STR_COLON = ":";
        public const string STR_PERIOD = ".";
        public const string STR_COMMA = ",";
        public const string STR_NEGATIVE = "-";

        [Tooltip("Character that shows up to the left of the number if it has less digits than available.")]
        public string leftCharacter = "0";

        [Tooltip("If true, commas will be used when appropriate.")]
        public bool useComma;

        /// <summary>
        /// The digits for text mesh pro.
        /// </summary>
        [SerializeField()]
        TextMeshProUGUI[] textMeshProDigits;

        string[] digits = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        int digitCount = 0;

        public TextMeshProUGUI[] TextMeshProDigits
        {
            get
            {
                return textMeshProDigits;
            }

            set
            {
                textMeshProDigits = value;
                digitCount = textMeshProDigits == null ? 0 : textMeshProDigits.Length;
                if (digitCount <= 0)
                {
                    Debug.LogError("Empty array provided");
                }
            }
        }

        private void Awake()
        {
            digitCount = textMeshProDigits == null ? 0 : textMeshProDigits.Length;
            if (digitCount <= 0)
            {
                Debug.LogError("Empty array provided");
            }
        }

        public void UpdateIntScore(int score)
        {
            long lScore = (long)score;
            UpdateScore(lScore, 0);
        }

        public void UpdateScoreFromFloat(float score, int decimalValue = 0)
        {
            // Rounds the score to an integer
            long lScore = (long)Mathf.Floor(score * Mathf.Pow(10, decimalValue));
            UpdateScore(lScore, decimalValue);
        }

        public void UpdateScore(long lScore, int decimalValue = 0)
        {
            bool negative = lScore < 0;
            if (negative)
                lScore *= -1;

            for (int i = 0; i < digitCount; i++)
            {
                if (decimalValue > 0 && i == decimalValue)
                {
                    textMeshProDigits[i].text = STR_PERIOD;
                }
                else if (lScore > 0)
                {
                    if (useComma && (i - 1 - decimalValue) % 4 == 3)
                    {
                        textMeshProDigits[i].text = STR_COMMA;
                    }

                    else
                    {
                        textMeshProDigits[i].text = digits[lScore % 10];
                        lScore /= 10;
                    }
                }
                else if (negative)
                {
                    textMeshProDigits[i].text = STR_NEGATIVE;
                    negative = false;
                }
                else
                {
                    textMeshProDigits[i].text = leftCharacter;
                }
            }
        }
    }
}