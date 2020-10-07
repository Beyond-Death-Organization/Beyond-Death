using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Playables;

namespace Traps
{
    public class AnimatedObject : MonoBehaviour
    {
        [Header("Animation")] 
        [SerializeField] protected PlayableDirector Timeline;
        [SerializeField] public float AnimationSpeed = 1;

        public Action OnReverseAnimationStopped;

        protected void PlayTimeline() {
            Timeline.Play();
            Timeline.playableGraph.GetRootPlayable(0).SetSpeed(AnimationSpeed);
        }

        protected void PlayTimelineReverse() {
            StartCoroutine(PlayTimelineReverseCoroutine());
        }

        protected void ResetTimeline() {
            Timeline.time = 0;
            Timeline.Evaluate();
        }

        private IEnumerator PlayTimelineReverseCoroutine() {
            double currentTime = Timeline.playableAsset.duration;

            while (currentTime > 0) {
                Timeline.time = currentTime;
                Timeline.Evaluate();

                currentTime -= Time.deltaTime;
                
                yield return null;
            }

            Timeline.time = 0;
            Timeline.Evaluate();
            Timeline.Stop();
            OnReverseAnimationStopped?.Invoke();
        }
    }
}