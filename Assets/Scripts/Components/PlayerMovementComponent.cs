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

    private Vector3 inputs;
    private void Start() {
        player = ReInput.players.GetPlayer("Player01");
        RigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        inputs.x = player.GetAxis("Horizontal");
        inputs.y = player.GetAxis("Vertical");

        RigidBody.AddForce(new Vector3(inputs.x, 0, inputs.y).normalized * (Speed * Time.deltaTime), ForceMode.VelocityChange);
    }
}
