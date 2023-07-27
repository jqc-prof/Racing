using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace JiaLab6
{
    public class LapFinish : MonoBehaviour
    {
        private int cLap = 1, AILap = 1;
        [SerializeField] public GameObject FinishLine;
        public TextMeshProUGUI lapCountText;
        public GameObject finishTrig;
        [SerializeField] public WinState WinStateScript;

       

        private void Update()
        {
            if(cLap > 3)
            {
                finishTrig.SetActive(false);
                WinStateScript.state = WinState.WoL.Lose;
            }
            if (AILap > 3)
            {
                finishTrig.SetActive(false);
                WinStateScript.state = WinState.WoL.Win;
            }
        }

        // Update is called once per frame
        public void trigger(Collider other)
        {
            Debug.Log("Entered");
            if (cLap < 4 && other.gameObject.CompareTag("PlayerCar"))
            {
                cLap++;
                lapCountText.text = cLap.ToString();
            }else
            {
                AILap++;
            }

        }

       
    }
}