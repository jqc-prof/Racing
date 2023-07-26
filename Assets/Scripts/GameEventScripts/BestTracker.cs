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
            HalfTrig.SetActive(true);
            FinishTrig.SetActive(false);
        }
    }
}