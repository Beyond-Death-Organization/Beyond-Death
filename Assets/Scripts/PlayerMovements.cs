using System;
using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovements : MonoBehaviour
{
    public float MovementSpeed = 10;
    [Tooltip("")]
    public float WorldRotation = -45;
    
    protected Rewired.Player playerRef;
    private Rigidbody rb;

    private Vector3 inputs;
    private Vector3 movements = Vector3.zero;
    
    protected virtual void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Start() { }

    protected virtual void Update() {
        inputs.x = playerRef.GetAxisRaw("Horizontal");
        inputs.z = playerRef.GetAxisRaw("Vertical");
    }

    protected virtual void FixedUpdate() {
        //Move Horizontal / Vertical
        movements.x = inputs.x;
        movements.z = inputs.z;
        movements = Quaternion.AngleAxis(WorldRotation, Vector3.up) * movements;

        rb.AddForce(movements.normalized * (MovementSpeed * Time.deltaTime), ForceMode.VelocityChange);
    }
}