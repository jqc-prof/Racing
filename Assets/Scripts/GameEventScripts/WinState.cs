using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JiaLab6
{

    public class WinState : MonoBehaviour
    {
        internal WoL state;

        public enum WoL
        {
            None,
            Win,
            Lose
        }
    }
}