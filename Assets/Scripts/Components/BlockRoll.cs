using System;
using System.Collections;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Rigidbody))]
    public class BlockRoll : InteractableObject
    {
        private float y;
        public float force = 10;

        private Rigidbody body;
        private void Awake()
        {
            y = transform.position.y;
            body = GetComponent<Rigidbody>();
        }

       /* private void FixedUpdate()
        {
            var position = transform.position;
            //wateposition.y = y;
            body.MovePosition(position);
        }*/
        // void OnCollisionEnter(Collision c)
        // {
        //     if (c.gameObject.layer == LayerMask.NameToLayer("Player"))
        //     {
        //         Vector3 dir = c.contacts[0].point - transform.position;
        //         dir = dir.normalized;
        //         body.AddForce(dir*force);
        //     }
        // }
    }
}