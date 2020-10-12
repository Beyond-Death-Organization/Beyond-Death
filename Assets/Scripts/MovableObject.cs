using System;
using Cinemachine;
using Rewired;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovableObject : MonoBehaviour
{
    public InputsComponent Inputs;
    public float MovementSpeed = 40;
    public float LerpRotationSpedd = 3;

    private Vector3 moveInputs;
    private Vector3 direction;

    private Camera cameraLookingAtPlayer;
    private Transform myTransform;
    protected Rigidbody myRigidBody;

    private float forwardAngle;
    private float turnVelocity;

    protected virtual void Awake() {
        cameraLookingAtPlayer = Camera.main;
        myTransform = transform;
        myRigidBody = GetComponent<Rigidbody>();
    }

    protected virtual void Start() {
        //TODO DO SOMEWHERE ELSE ON MAIN BRANCH
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    protected virtual void Update() {
        moveInputs.x = Inputs.Player.GetAxisRaw("Horizontal");
        moveInputs.z = Inputs.Player.GetAxisRaw("Vertical");
    }

    protected virtual void FixedUpdate() {
        //Move depending on Camera rotation
        direction.x = moveInputs.x;
        direction.z = moveInputs.z;
        direction = Quaternion.AngleAxis(forwardAngle, Vector3.up) * direction;

        //Normalize + adjust with Time.deltaTime
        Vector3 movementsNormalized = direction.normalized * (MovementSpeed * Time.deltaTime);

        //Rotate player toward movement direction
        if (moveInputs.sqrMagnitude >= 0.1f)
            myTransform.rotation = Quaternion.LookRotation(movementsNormalized);

        //Update forward vector
        forwardAngle = Mathf.SmoothDampAngle(forwardAngle, cameraLookingAtPlayer.transform.rotation.eulerAngles.y,
            ref turnVelocity, Time.deltaTime);

        //Set
        movementsNormalized.y = myRigidBody.velocity.y;
        myRigidBody.velocity = movementsNormalized;
    }
}