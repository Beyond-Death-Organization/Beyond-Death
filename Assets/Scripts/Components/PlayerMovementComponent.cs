using System;
using Rewired;
using UnityEngine;

public class PlayerMovementComponent : MonoBehaviour
{
    public bool EnableMovement = true;
    public float Speed;
    private Rigidbody RigidBody;
    public float WorldRotation = -45;

    private Player player;
    private int horizontalAxisId, verticalAxisId;    //TODO TO AVOID STRING COMPARISION

    private Vector3 inputs = Vector3.zero;
    private void Start() {
        player = ReInput.players.GetPlayer("Player01");
        RigidBody = GetComponent<Rigidbody>();
        GameManager.Instance.OnNextLevel.AddListener(arg0 => transform.position = ((GameObject)GameVariables.References["StartPosition"]).transform.position);
    }

    private void FixedUpdate()
    {
        if (!EnableMovement) { return; }
        
        inputs.x = player.GetAxis("Horizontal");
        inputs.z = player.GetAxis("Vertical");
        
        Vector3 pos = new Vector3(inputs.x, 0, inputs.z);
        pos = Quaternion.AngleAxis(WorldRotation, Vector3.up) * pos;
        
        if ((inputs.x < 0.1f &&  inputs.z < 0.1f) && (inputs.x > -0.1f &&  inputs.z > -0.1f))
        {
            inputs = Vector3.zero;
            RigidBody.velocity = inputs;
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(pos);
            
            RigidBody.MovePosition(RigidBody.position + pos * (Speed * Time.deltaTime));
        }
    }
}
