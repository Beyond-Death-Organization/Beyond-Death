using UnityEngine;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance = null;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
        public void Play(AudioClip clip, AudioSource EffectsSource)
        {
            EffectsSource.clip = clip;
            EffectsSource.Play();
        }

        // Play a single clip through the music source.
        public void PlayMusic(AudioClip clip, AudioSource MusicSource)
        {
            MusicSource.clip = clip;
            MusicSource.loop = true;
            MusicSource.Play();
        }

    }
}