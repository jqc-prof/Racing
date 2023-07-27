using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace JiaLab6
{

    public class WinState : MonoBehaviour
    {
        internal WoL state = WoL.None;
        public GameObject timerScreen;
        public GameObject WinScreen;
        public GameObject LoseScreen;
        [SerializeField] public TextMeshProUGUI bestMin;
        [SerializeField] public TextMeshProUGUI bestSec;
        [SerializeField] public TextMeshProUGUI bestMil;

        [SerializeField] private TextMeshProUGUI bestMinToChange;
        [SerializeField] private TextMeshProUGUI bestSecToChange;
        [SerializeField] private TextMeshProUGUI bestMilToChange;



        public enum WoL
        {
            None,
            Win,
            Lose
        }

        private void Update()
        {
            switch (state)
            {
                case (WoL.Win):
                    timerScreen.SetActive(false);
                    WinScreen.SetActive(true);
                    ChangeScore();
                    //Display win screen
                    break;
                case (WoL.Lose):
                    timerScreen.SetActive(false);
                    //Display lose screen
                    LoseScreen.SetActive(true);
                    break;
                default:
                    break;
            }
        }

        private void ChangeScore()
        {
            bestMinToChange.text = bestMin.text;
            bestSecToChange.text = bestSec.text;
            bestMilToChange.text = bestMil.text;

        }
    }
}