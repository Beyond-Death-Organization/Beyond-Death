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
        GameManager.Instance.OnNextLevel.AddListener(arg0 => {
            transform.position = spawnPosition;
            transform.rotation = spawnRotation;
        });
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;
        
        Vector3 pos = new Vector3(inputs.x, 0, inputs.z);
        pos = Quaternion.AngleAxis(WorldRotation, Vector3.up) * pos;
        
        velocity.y += -9.81f * Time.deltaTime;
        Controller.Move(pos.normalized * (Mathf.Clamp01(pos.magnitude) * (Speed * Time.deltaTime)));
        Controller.Move(velocity * Time.deltaTime);

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