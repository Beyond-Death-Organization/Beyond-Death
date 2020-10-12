using System;
using UnityEngine;


public abstract class JumpAbleObject : MovableObject
{
    public float JumpForce = 5;

    [Tooltip("EmptyGameObject placed at bottom of object")]
    public Transform GroundCheck;
    public LayerMask GroundMask;

    private const float sphereCastRadius = 0.01f;

    protected override void Update() {
        base.Update();
        
        if(Inputs.Player.GetButton("Jump"))
            if (IsGrounded())
                Jump();
    }

    private void Jump() {
        Vector3 velocity = myRigidBody.velocity;
        myRigidBody.velocity = new Vector3(velocity.x, JumpForce * 0.1f, velocity.z);
        //myRigidBody.AddForce(0, JumpForce * 0.01f, 0, ForceMode.Impulse);
    }

    private bool IsGrounded() {
        return Physics.CheckSphere(GroundCheck.position, sphereCastRadius, GroundMask);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(GroundCheck.position, sphereCastRadius);
    }
}
