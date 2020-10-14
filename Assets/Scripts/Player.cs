using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : JumpAbleObject
{
    public Animator Animator;

    private Vector3 movementSpeed;
    
    protected override void Awake() {
        base.Awake();
    }

    protected override void Start() {
        base.Start();
    }

    protected override void Update() {
        base.Update();
        movementSpeed.x = myRigidBody.velocity.x;
        movementSpeed.z = myRigidBody.velocity.z;
        Animator.SetFloat("MovementSpeed", movementSpeed.magnitude);
    }

    protected override void FixedUpdate() {
        base.FixedUpdate();
    }
}
