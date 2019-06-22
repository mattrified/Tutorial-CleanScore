using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MattrifiedGames.UIHelper.Demo
{
    public class CleanTimerDemo : MonoBehaviour
    {
        public CleanTimer cleanTimer;

        public bool paused;
        public bool Paused { get { return paused; } set { paused = value; } }

        [SerializeField(), Range(0, MAX_TIME)]
        float time = 0f;

        // 99 minutes in seconds.
        const float MAX_TIME = 5940f;

        public bool updateString;
        public bool UpdateString { get { return updateString; } set { updateString = value; } }
        public TextMeshProUGUI textMeshProString;

        string formatString = @"mm\:ss\:fff";

        // Update is called once per frame
        void Update()
        {
            if (!paused)
            {
                time += Time.deltaTime;
            }
            time = Mathf.Min(time, MAX_TIME);
            cleanTimer.UpdateTime(time);

            if (updateString)
            {
                textMeshProString.text = System.TimeSpan.FromSeconds(time).ToString(formatString);
            }
        }
    }
}