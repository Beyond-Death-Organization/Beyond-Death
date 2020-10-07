using UnityEngine;

namespace Traps
{
    public class AnimatedObjectWithSound : AnimatedObject
    {
        [SerializeField] private AudioSource Source;
        [SerializeField] public AudioClip Clip;
        
        public void PlaySound() {
            Source.clip = Clip;
            Source.Play();
        }
    }
}