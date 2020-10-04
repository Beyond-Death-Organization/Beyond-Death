using System;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance = null;
        public List<AudioWrapper> audiosClip;
        //public List<AudioWrapper> audiosMusic;
        public Dictionary<string, AudioClip> clips;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                clips = new Dictionary<string, AudioClip>();
                foreach (var audioclip in audiosClip)
                {
                    clips.Add(audioclip.AudioName, audioclip.AudioClip);
                }
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            
        }

        public void PlayClip(string clipName, AudioSource effectsSource)
        {
            //effectsSource.clip = clips[clipName];
            effectsSource.spatialBlend = 1;
            effectsSource.PlayOneShot(clips[clipName]);
        }

        // Play a single clip through the music source.
        public void PlayMusic(string clipName, AudioSource MusicSource)
        {
            
            MusicSource.clip = clips[clipName];
            MusicSource.loop = true;
            MusicSource.spatialBlend = 0;
            MusicSource.Play();
        }
        [Serializable]
        public class AudioWrapper
        {
            public string AudioName;
            public AudioClip AudioClip;
        }
    }
}