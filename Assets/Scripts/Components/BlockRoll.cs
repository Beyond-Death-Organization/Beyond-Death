using System;
using System.Collections;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Rigidbody))]
    public class BlockRoll : InteractableObject
    {
        private float y;
        private Rigidbody body;
        private void Awake()
        {
            y = transform.position.y;
            body = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            var position = transform.position;
            position.y = y;
            body.MovePosition(position);
        }
    }
}