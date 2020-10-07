using System.Collections.Generic;
using UnityEngine;

namespace Traps
{
    public class AnimatedObjectWithSounds : AnimatedObject
    {
        [SerializeField] private AudioSource Source;
        [SerializeField] public List<AudioClip> Clips;

        public void PlaySound() {
            Source.clip = GetRandomClip();
            Source.Play();
        }

        private AudioClip GetRandomClip() {
            return Clips[Random.Range(0, Clips.Count)];
        }
    }
}