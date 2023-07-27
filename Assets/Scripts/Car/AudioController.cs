using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JiaLab6;

namespace JiaLab6
{

    public class AudioController : MonoBehaviour
    {

        public enum EngineAudioOptions
        {
            Simple
        }

        [SerializeField] private Camera cam;
        public EngineAudioOptions engineSoundStyle = EngineAudioOptions.Simple;
        public AudioClip lowAccelClip;
        public AudioClip lowDecelClip;
        public AudioClip highAccelClip;
        public AudioClip highDecelClip;

        private AudioSource highAccelSource;
        private AudioSource lowAccelSource;
        private AudioSource lowDecelSource;
        private AudioSource highDecelSource;
        private CarController carController;

        private const float lowPitchMin = 1f;
        private const float lowPitchMax = 6f;
        private const float pitchMultiplier = 1f;
        private const float highPitchMultiplier = 0.25f;
        private const float maxRolloffDistance = 500f;
        private const float dopplerLevel = 1f;
        private const bool useDoppler = true;

        private bool isSoundPlaying;

        private void Start()
        {
            carController = GetComponent<CarController>();
            highAccelSource = SetUpEngineAudioSource(highAccelClip);

            isSoundPlaying = true;
        }

        private void Update()
        {
            float camDist = (cam.transform.position - transform.position).sqrMagnitude;

            if (isSoundPlaying && camDist > maxRolloffDistance * maxRolloffDistance)
            {
                StopSound();
            }

            if (!isSoundPlaying && camDist < maxRolloffDistance * maxRolloffDistance)
            {
                StartSound();
            }

            if (isSoundPlaying)
            {
                float pitch = Mathf.Lerp(lowPitchMin, lowPitchMax, CarController.currentAcc);
                pitch = Mathf.Min(lowPitchMax, pitch);

                highAccelSource.pitch = pitch * pitchMultiplier * highPitchMultiplier;
                highAccelSource.dopplerLevel = useDoppler ? dopplerLevel : 0;
                highAccelSource.volume = 1;
                
            }
        }

        private void StartSound()
        {
            carController = GetComponent<CarController>();
            highAccelSource = SetUpEngineAudioSource(highAccelClip);

            
            lowAccelSource = SetUpEngineAudioSource(lowAccelClip);
            lowDecelSource = SetUpEngineAudioSource(lowDecelClip);
            highDecelSource = SetUpEngineAudioSource(highDecelClip);

            isSoundPlaying = true;
        }

        private void StopSound()
        {
            Destroy(highAccelSource);
            isSoundPlaying = false;
        }

        private AudioSource SetUpEngineAudioSource(AudioClip clip)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = clip;
            source.volume = 0;
            source.loop = true;
            source.time = Random.Range(0f, clip.length);
            source.Play();
            source.minDistance = 5f;
            source.maxDistance = maxRolloffDistance;
            source.dopplerLevel = 0f;
            return source;
        }

        private static float Lerp(float from, float to, float value)
        {
            return (1f - value) * from + value * to;
        }
    }
}