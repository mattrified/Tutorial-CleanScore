using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CleanScore : MonoBehaviour
{
    public TextMeshProUGUI[] digitsText;

    public int score;

    string[] digits = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    public TextMeshProUGUI altDigitsText;
    string format = "Score:  {0:D11}";

    void Update()
    {
        int s = score;
        for (int i = 0; i < digitsText.Length; i++)
        {
            if (s > 0)
            {
                digitsText[i].text = digits[s % 10];
                s /= 10;
            }
            else
            {
                digitsText[i].text = digits[0];
            }
        }

        score += Random.Range(1, 10);

        //altDigitsText.text = string.Format(format, score);
    }
}