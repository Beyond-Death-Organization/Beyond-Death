using System;
using System.Collections;
using UnityEngine;

namespace Components
{
    public class Spike : InteractableObject
    {
        public Rigidbody Spikes;
        public float WaitTime;
        public AnimationCurve SpikeCurve;
        public float Duration;
        public float Height = 1;
        private bool hasEnter;
        private Vector3 initialPosition;

        private void Awake()
        {
            initialPosition = Spikes.position;
        }

        public override void OnEnter(Collider other)
        {
            if (!hasEnter)
            {
                TimedActionManager.Instance.AddTimedAction(() => StartCoroutine(Boom(other)), WaitTime);
                hasEnter = true;
            }
        }

        IEnumerator Boom(Collider other)
        {
            var time = Time.time;
            float set = 0;
            
            while (time + Duration > Time.time)
            {
                var spikePosition = initialPosition;
                spikePosition.y = initialPosition.y + SpikeCurve.Evaluate(set / Duration) * Height;
                Spikes.MovePosition(spikePosition);
                set += Time.deltaTime;
                yield return null;
            }
        }
        
    }
}