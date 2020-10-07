using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traps
{
    public class SpikeIntelligent : AnimatedObjectWithSound
    {
        [HideInInspector] public bool IsTriggered = false;

        private void Awake() {
#if UNITY_EDITOR
            if (!GetComponent<Collider>().isTrigger)
                Debug.LogWarning(
                    $"Collision won't be detected on {transform.name} because collider isn't set to trigger...");
#endif
            OnReverseAnimationStopped += () => { IsTriggered = false; };
        }

        public virtual void OnTriggerEnter(Collider other) {
            if (!IsTriggered) 
                OnActivation();
        }

        public virtual void OnActivation() {
            IsTriggered = true;
            PlayTimeline();
        }

        public virtual void OnDeactivation() {
            PlayTimelineReverse();
        }

        /// <summary>
        /// Plays the timeline reverse without sound
        /// </summary>
        protected void PlayReverse() {
            OnDeactivation();
        }

        /*public void ResetTrap() {
            ResetTimeline();
            OnDeactivation();
        }*/
    }
}