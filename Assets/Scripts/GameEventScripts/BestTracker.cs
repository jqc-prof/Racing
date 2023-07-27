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

        private int cLap = 1, AILap = 1;
        public TextMeshProUGUI lapCountText;
        [SerializeField] public WinState WinStateScript;



        private void Update()
        {
            if (cLap > 3)
            {
                FinishTrig.SetActive(false);
                WinStateScript.state = WinState.WoL.Win;
            }
            if (AILap > 3)
            {
                FinishTrig.SetActive(false);
                WinStateScript.state = WinState.WoL.Lose;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("PlayerCar"))
            {
                float currentTime = LapTimeController.minutes + LapTimeController.seconds + LapTimeController.minutes;
                if (currentTime < bestTime)
                {
                    bestTime = currentTime;
                    secBest.text = LapTimeController.seconds.ToString("00") + ".";
                    minBest.text = LapTimeController.minutes.ToString("00") + ":";
                    milBest.text = LapTimeController.milliseconds.ToString("000");
                }
                if (cLap < 4 && other.gameObject.CompareTag("PlayerCar"))
                {
                    cLap++;
                    lapCountText.text = cLap.ToString();
                }
                else
                {
                    AILap++;
                }
                LapTimeController.totalTime = 0f;
                
            }
          
        }
    }
}