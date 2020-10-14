using System;
using Cinemachine;
using Rewired;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class MovableObject : MonoBehaviour
{
    public InputsComponent Inputs;
    public float MovementSpeed = 40;
    public float RotationLerpSpeed = 7;

    private Vector3 moveInputs;
    private Vector3 direction;
    private Vector3 movementsNormalized;

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
        movementsNormalized = direction.normalized * (MovementSpeed * Time.deltaTime);

        //Rotate player toward movement direction (slerp)
        if (moveInputs.sqrMagnitude >= 0.1f)
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(movementsNormalized),
                Time.deltaTime * RotationLerpSpeed);
        else
            movementsNormalized = Vector3.zero;
        //myTransform.rotation = Quaternion.LookRotation(movementsNormalized);

        //Update forward vector
        forwardAngle = Mathf.SmoothDampAngle(forwardAngle, cameraLookingAtPlayer.transform.rotation.eulerAngles.y,
            ref turnVelocity, Time.deltaTime);

        //Set
        movementsNormalized.y = myRigidBody.velocity.y;
        myRigidBody.velocity = movementsNormalized;
    }
}