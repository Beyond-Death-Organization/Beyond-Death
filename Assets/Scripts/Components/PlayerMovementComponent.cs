using System;
using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class PlayerMovementComponent : MonoBehaviour
{
    public float Speed;
    public Rigidbody RigidBody;

    private Player player;
    private int horizontalAxisId, verticalAxisId;    //TODO TO AVOID STRING COMPARISION

    private Vector3 inputs;
    private void Start() {
        player = ReInput.players.GetPlayer("Player01");
    }

    private void Update()
    {
        inputs.x = player.GetAxis("Horizontal");
        inputs.y = player.GetAxis("Vertical");
    }

    private void FixedUpdate() {
        float horizontal = inputs.x * Speed * Time.fixedDeltaTime;
        float vertical = inputs.y * Speed * Time.fixedDeltaTime;
        
        RigidBody.velocity = new Vector3(horizontal, 0, vertical).normalized;
    }
}
