using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTrigger : MonoBehaviour
{
    public GameObject FinishTrigger;
    public GameObject HalfTrigger;

    private void OnTriggerEnter(Collider other)
    {
        FinishTrigger.SetActive(true);
        HalfTrigger.SetActive(false);
        Debug.Log("Finish trigger is: " + FinishTrigger.activeSelf);
    }
}
