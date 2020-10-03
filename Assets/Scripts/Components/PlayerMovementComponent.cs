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

    private void Start() {
        player = ReInput.players.GetPlayer("Player01");
    }

    private void Update() {
        float horizontal = player.GetAxis("Horizontal") * Speed;
        float vertical = player.GetAxis("Vertical") * Speed;
        
        RigidBody.AddForce(horizontal, 0, vertical, ForceMode.VelocityChange);
    }
}
