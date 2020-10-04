using System;
using Rewired;
using UnityEngine;

public class PlayerMovementComponent : MonoBehaviour
{
    public bool EnableMovement = true;
    public float Speed;
    private Rigidbody rigidBody;
    private Animator animator;
    public float WorldRotation = -45;

    private Player player;
    private Vector3 spawnPosition;
    private Quaternion spawnRotation;
    private int horizontalAxisId, verticalAxisId; //TODO TO AVOID STRING COMPARISION

    private Vector3 inputs = Vector3.zero;

    private void Start() {
        player = ReInput.players.GetPlayer("Player01");
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        spawnPosition = transform.position;
        spawnRotation = transform.rotation;
        
        GameManager.Instance.OnNextLevel.AddListener(arg0 => {
            transform.position = spawnPosition;
            transform.rotation = spawnRotation;
        });
    }

    private void FixedUpdate()
    {
        if (!EnableMovement) { return; }
        
        inputs.x = player.GetAxis("Horizontal");
        inputs.z = player.GetAxis("Vertical");
        
        Vector3 pos = new Vector3(inputs.x, 0, inputs.z);
        pos = Quaternion.AngleAxis(WorldRotation, Vector3.up) * pos;
        
        if (inputs.x < 0.1f &&  inputs.z < 0.1f && (inputs.x > -0.1f &&  inputs.z > -0.1f))
        {
            inputs = Vector3.zero;
            rigidBody.velocity = inputs;
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(pos);
            rigidBody.MovePosition(rigidBody.position + pos.normalized * (Mathf.Clamp01(pos.magnitude) * (Speed * Time.deltaTime)));
        }
        
        animator.SetFloat("Speed", Mathf.Clamp01(inputs.magnitude));
    }
}