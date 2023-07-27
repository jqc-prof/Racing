using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JiaLab6;

namespace JiaLab6 {
    public class CountDown : MonoBehaviour
    {
        public TextMeshProUGUI count;
        public AudioSource ready;
        public AudioSource go;
        private Animator animator;
        // Start is called before the first frame update
        void Start()
        {
            animator = count.gameObject.GetComponent<Animator>();
            StartCoroutine(startCount());
        }

        IEnumerator startCount()
        {
            gameObject.SetActive(true);
            count.text = "3";
            ready.Play();
            yield return new WaitForSeconds(1f);
            count.text = "2";
            ready.Play();
            yield return new WaitForSeconds(1f);
            count.text = "1";
            ready.Play();
            yield return new WaitForSeconds(1f);
            count.text = "";
            animator.enabled = false;
            go.Play();
            gameObject.SetActive(false);
        }
    }
}