using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JiaLab6;

namespace JiaLab6
{
    public class BestTracker : MonoBehaviour
    {
        public TextMeshProUGUI minBest;
        public TextMeshProUGUI secBest;
        public TextMeshProUGUI milBest;

        public GameObject HalfTrig;
        public GameObject FinishTrig;
        private float bestTime = Mathf.Infinity;

        private void OnTriggerEnter(Collider other)
        {
            float currentTime = LapTimeController.minutes + LapTimeController.seconds + LapTimeController.minutes;
            if(currentTime < bestTime)
            {
                bestTime = currentTime;
                secBest.text = LapTimeController.seconds.ToString("00") + ".";
                minBest.text = LapTimeController.minutes.ToString("00") + ":";
                milBest.text = LapTimeController.milliseconds.ToString("000");
                LapTimeController.totalTime = 0f;
            }
            /*
            if(LapTimeController.seconds <= 9)
            {
                secBest.text = LapTimeController.seconds.ToString("00") + ".";
            }
            else
            {
                secBest.text = LapTimeController.seconds.ToString("0") + ".";
            }

            if (LapTimeController.minutes <= 9)
            {
                milBest.text = LapTimeController.minutes.ToString("00") + ".";
            }
            else
            {
                milBest.text = LapTimeController.minutes.ToString("0") + ".";
            }*/
            HalfTrig.SetActive(true);
            FinishTrig.SetActive(false);
        }
    }
}