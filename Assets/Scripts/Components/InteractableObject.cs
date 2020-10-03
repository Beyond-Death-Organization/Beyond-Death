using System;
using UnityEngine;

namespace Components
{
    public class InteractableObject : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            OnEnter(other);
        }
        private void OnTriggerExit(Collider other)
        {
            OnExit(other);
        }

        private void OnTriggerStay(Collider other)
        {
            OnStay(other);
        }

        public virtual void OnEnter(Collider other) { }
        public virtual void OnExit(Collider other) { }
        public virtual void OnStay(Collider other) { }
    }
}