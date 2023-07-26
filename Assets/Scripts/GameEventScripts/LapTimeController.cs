using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace JiaLab6
{
    public class LapTimeController : MonoBehaviour
    {
        public TextMeshProUGUI min;
        public TextMeshProUGUI sec;
        public TextMeshProUGUI mil;
        public static float totalTime = 0f; // Variable to store the total time
        public GameObject countdown;

        public static int minutes;
        public static int seconds;
        public static int milliseconds;
        void Update()
        {
            
            if (!countdown.activeSelf)
            {
                // Calculate minutes, seconds, and milliseconds directly from Time.deltaTime
                float deltaTime = Time.deltaTime;
                totalTime += deltaTime; // Add the deltaTime to the total time

                minutes = (int)(totalTime / 60f);
                seconds = (int)(totalTime % 60f);
                milliseconds = (int)((totalTime * 1000) % 1000);

                // Display the values on the TextMeshProUGUI components
                min.text = minutes.ToString("00") + ":";
                sec.text = seconds.ToString("00") + ".";
                mil.text = milliseconds.ToString("000");
            }
        }

    }
}