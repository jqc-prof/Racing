using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace JiaLab6
{
    public class LapFinish : MonoBehaviour
    {
        private int currentLap;
        [SerializeField] private GameObject FinishLine;
        public TextMeshProUGUI lapCountText;
        public GameObject finishTrig;

        void Start()
        {
            currentLap = 1;
        }

        private void Update()
        {
            if(currentLap > 3)
            {
                finishTrig.SetActive(false);
            }
        }

        // Update is called once per frame
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Lap +");

            if (currentLap <= 3 && other.gameObject == FinishLine)
            {
                Debug.Log("Lap +");
                currentLap++;
                lapCountText.text = currentLap.ToString();
            }
        }
    }
}