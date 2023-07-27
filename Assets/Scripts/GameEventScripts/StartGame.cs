using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace JiaLab6
{
    public class StartGame : MonoBehaviour
    {
        [SerializeField] private Camera CarCamera;
        [SerializeField] private Camera MainCamera;
        [SerializeField] public GameObject TimeManager;
        [SerializeField] public GameObject TimerScreen;
        [SerializeField] public GameObject StartScreen;

        public void OnButtonClick()
        {
            MainCamera.enabled = false;
            CarCamera.enabled = true;
            StartScreen.SetActive(false);
            TimeManager.SetActive(true);
            TimerScreen.SetActive(true);
        }

    }
}