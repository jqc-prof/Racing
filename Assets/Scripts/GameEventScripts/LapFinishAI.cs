using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JiaLab6;

namespace JiaLab6
{


    public class LapFinishAI : MonoBehaviour
    {
        private int currentLap;
        [SerializeField] private GameObject FinishLine;
        public GameObject finishTrig;

        void Start()
        {
            currentLap = 1;
        }

        private void Update()
        {
            if (currentLap > 3)
            {
                finishTrig.SetActive(false);
            }
        }

        // Update is called once per frame
        private void OnTriggerEnter(Collider other)
        {
            if (currentLap <= 3 && other.gameObject == FinishLine)
            {
                currentLap++;
            }
        }
    }
}
