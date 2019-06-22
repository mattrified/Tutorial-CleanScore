using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MattrifiedGames.UIHelper
{
    public class CleanScore : CleanScoreBase
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

        [SerializeField(), Tooltip("Array of text mesh pro objects used to display each character in the score.")]
        TextMeshProUGUI[] textMeshProDigits = new TextMeshProUGUI[0];

        /// <summary>
        /// The digits used for displaying score.
        /// </summary>
        string[] digits = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        /// <summary>
        /// The number of digits displayed
        /// </summary>
        int digitCount = 0;

        /// <summary>
        /// Property for setting the displayed digits as the digit count needs to adjust based on the array size.
        /// </summary>
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
                Debug.LogError("Empty array provided by " + name);
            }
        }

        /// <summary>
        /// Updates the score.
        /// </summary>
        /// <param name="lScore">The long value</param>
        /// <param name="decimalValue">The number of decimal places.  Defaults as 0.</param>
        public override void UpdateScore(long lScore, int decimalValue = 0)
        {
            // sets if the supplied score is negative and makes it positive.
            bool negative = lScore < 0;
            if (negative)
                lScore *= -1;

            // Goes through the number of digits we want to display.
            for (int i = 0; i < digitCount; i++)
            {
                // If we are using a decimal at the requested spot, the period string is used.
                if (decimalValue > 0 && i == decimalValue)
                {
                    textMeshProDigits[i].text = STR_PERIOD;
                }
                else if (lScore > 0) // If the score value is greater than 0, meaning there are digits to use.
                {
                    // If we are using a comma, we test if it's the third in a set but after the decimal
                    if (useComma && (i - decimalValue - 1 * Mathf.Clamp01(decimalValue)) % 4 == 3)
                    {
                        textMeshProDigits[i].text = STR_COMMA;
                    }
                    else
                    {
                        // Set the string based on the mod of 10 in the current score
                        textMeshProDigits[i].text = digits[lScore % 10];

                        // Divide the score by ten.
                        lScore /= 10;
                    }
                }
                else if (negative) // If it was negative, we show a dash.
                {
                    textMeshProDigits[i].text = STR_NEGATIVE;
                    negative = false;
                }
                else // any remaining digits use the left character string.
                {
                    textMeshProDigits[i].text = leftCharacter;
                }
            }
        }
    }
}