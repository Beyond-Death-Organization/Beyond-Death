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
        private bool hasExit;
        private Vector3 initialPosition;
        public Collider coll;
        public GameObject toEnable;
        public bool loop;
        public TriggerComponent TriggerComponent;
        private bool hasHit;
        private void Awake()
        {
            initialPosition = Spikes.position;
            if (loop)
            {
                TimedActionManager.Instance.AddTimedAction(Execute, WaitTime);
                hasEnter = true;
            }
            TriggerComponent.onTriggerEnter.AddListener(() => hasHit = true);
        }

        public override void OnEnter(Collider other)
        {
            if (!hasEnter)
            {
                TimedActionManager.Instance.AddTimedAction(Execute, WaitTime);
                hasEnter = true;
            }
            
        }

        IEnumerator Boom()
        {
            toEnable.SetActive(true);
            var time = Time.time;
            float set = 0;
            
            while (time + Duration > Time.time && !hasHit)
            {
                var spikePosition = initialPosition;
                spikePosition.y = initialPosition.y + SpikeCurve.Evaluate(set / Duration) * Height;
                Spikes.MovePosition(spikePosition);
                set += Time.deltaTime;
                yield return null;
            }

            if (hasHit)
            {
                var spikePosition = initialPosition;
                spikePosition.y = initialPosition.y + 1 * Height;
                Spikes.MovePosition(spikePosition);
            }

            if (loop && !hasHit)
            {
                Execute();
            }
            else
            {
                hasEnter = false;
            }
            
        
        }

        private void Execute()
        {
            StartCoroutine(Boom());
            hasEnter = true;
        }

        private void OnDrawGizmos()
        {
            if (coll == null) return;
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(coll.bounds.center, coll.bounds.size);
            Gizmos.DrawLine(coll.gameObject.transform.position, coll.gameObject.transform.position + Vector3.up / 2);
        }
    }
}