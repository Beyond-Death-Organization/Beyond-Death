using UnityEngine;

namespace Traps
{
    /// <summary>
    /// Always animate
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class SpikeDumb : AnimatedObjectWithSound
    {
        [HideInInspector] public bool IsTriggered = false;
        public float ActivationDelay = 2, DelayBeforeReset = 1.5f;

        private float timeBeforeActivation, timeBeforeReset;
        private bool isSpikeMoving = false;

        private void Awake() {
#if UNITY_EDITOR
            if (!GetComponent<Collider>().isTrigger)
                Debug.LogWarning(
                    $"Collision won't be detected on {transform.name} because collider isn't set to trigger...");
#endif
            timeBeforeActivation = ActivationDelay;
            Timeline.stopped += director => { isSpikeMoving = false; };
            OnReverseAnimationStopped += () => { isSpikeMoving = false; };
        }

        public virtual void Update() {
            if (isSpikeMoving)
                return;

            if (IsTriggered) {
                if (timeBeforeReset > 0)
                    timeBeforeReset -= Time.deltaTime;
                else
                    OnDeactivation();
            }
            else {
                if (timeBeforeActivation > 0)
                    timeBeforeActivation -= Time.deltaTime;
                else
                    OnActivation();
            }
        }

        public virtual void OnActivation() {
            timeBeforeReset = DelayBeforeReset;
            isSpikeMoving = true;
            IsTriggered = true;
            PlayTimeline();
        }

        public virtual void OnDeactivation() {
            timeBeforeActivation = ActivationDelay;
            IsTriggered = false;
            PlayReverse();
        }

        /// <summary>
        /// Plays the timeline reverse without sound
        /// </summary>
        protected void PlayReverse() {
            isSpikeMoving = true;
            PlayTimelineReverse();
        }

        private void SetIsMoving(bool enable) {
            isSpikeMoving = enable;
        }

        /*public void ResetTrap() {
            ResetTimeline();
            OnDeactivation();
        }*/
    }
}