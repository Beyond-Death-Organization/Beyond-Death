using System;
using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class PlayerMovementComponent : MonoBehaviour
{
    public float Speed;
    private Rigidbody RigidBody;

    private Player player;
    private int horizontalAxisId, verticalAxisId;    //TODO TO AVOID STRING COMPARISION

    private Vector3 inputs = Vector3.zero;
    private void Start() {
        player = ReInput.players.GetPlayer("Player01");
        RigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        inputs.x = player.GetAxis("Horizontal");
        inputs.z = player.GetAxis("Vertical");

        if ((inputs.x < 0.01f &&  inputs.z < 0.01f) && (inputs.x > -0.01f &&  inputs.z > -0.01f))
        {
            inputs = Vector3.zero;
            RigidBody.velocity = inputs;
        }

        
        RigidBody.AddForce(inputs * (Speed * Time.deltaTime), ForceMode.Impulse);
    }
}
