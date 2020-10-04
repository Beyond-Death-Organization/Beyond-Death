using System;
using Rewired;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementComponent : MonoBehaviour
{
    public float Speed;
    public float WorldRotation = -45;

    private Player player;
    private Vector3 spawnPosition;
    private Quaternion spawnRotation;
    private int horizontalAxisId, verticalAxisId; //TODO TO AVOID STRING COMPARISION
    private Animator animator;

    private Vector3 inputs = Vector3.zero;

    public Transform GroundCheck;
    public float GroundDistance = 0f;
    public LayerMask GroundMask;
    public CharacterController Controller;
    private Vector3 velocity;
    private bool isGrounded;
    private void Start() {
        player = ReInput.players.GetPlayer("Player01");
        animator = GetComponent<Animator>();
        spawnPosition = transform.position;
        spawnRotation = transform.rotation;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;
        
        Vector3 pos = new Vector3(inputs.x, 0, inputs.z);
        pos = Quaternion.AngleAxis(WorldRotation, Vector3.up) * pos;
        
        velocity.y += -9.81f * Time.fixedDeltaTime;
        Controller.Move(pos.normalized * (Mathf.Clamp01(pos.magnitude) * (Speed * Time.fixedDeltaTime)));
        Controller.Move(velocity * Time.fixedDeltaTime);

        if (!(inputs.sqrMagnitude < 0.01f))
            transform.rotation = Quaternion.LookRotation(pos);
    }

    private void Update()
    {
        inputs.x = player.GetAxis("Horizontal");
        inputs.z = player.GetAxis("Vertical");
        animator.SetFloat("Speed", inputs.magnitude);
    }
}