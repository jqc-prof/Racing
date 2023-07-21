using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JiaLab6
{

    public class AudioController : MonoBehaviour
    {
        // Start is called before the first frame update
        public List<AudioClip> audioClipsList = new List<AudioClip>();
        [SerializeField] private AudioSource audioSource;
        private bool isAudioPlaying = false;

        void Start()
        {
            // Check if the AudioSource component is attached
            if (audioSource == null)
            {
                Debug.LogError("AudioSource component is missing on " + gameObject.name);
                return; // Do not proceed further since AudioSource is not available
            }
            foreach (AudioClip ad in audioClipsList)
            {
                Debug.Log("Clip names: " + ad.name);
            }
        }

        public void PlayAudio(int TrackToPlay)
        {
            if (!isAudioPlaying)
            {
                audioSource.clip = audioClipsList[TrackToPlay];
                audioSource.Play();
                isAudioPlaying = true;
                StartCoroutine(WaitForAudioToFinish());
            }
        }

        IEnumerator WaitForAudioToFinish()
        {
            while (audioSource.isPlaying)
            {
                yield return null;
            }
            isAudioPlaying = false;
        }
    }
}