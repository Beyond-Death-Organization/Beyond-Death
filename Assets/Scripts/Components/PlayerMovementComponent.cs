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

    private void Start() {
        player = ReInput.players.GetPlayer("Player01");
        RigidBody = GetComponent<Rigidbody>();
    }

    private void Update() {
        float horizontal = player.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float vertical = player.GetAxis("Vertical") * Speed * Time.deltaTime;
        
        RigidBody.AddForce(horizontal, 0, vertical, ForceMode.VelocityChange);
    }
}
