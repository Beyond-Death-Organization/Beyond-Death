using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovements : MonoBehaviour
{
    public float MovementSpeed = 40;
    [Tooltip("Camera looking at player")] public Camera Camera;
    
    protected Rewired.Player playerRef;

    private Rigidbody rb;
    private Vector3 inputs;
    private Vector3 direction;

    private Transform myTransform;

    private const float rotationTargetOffset = 1;
    private Vector3 rotationTarget;

    protected virtual void Awake() {
#if UNITY_EDITOR
        if (Camera == null)
            Debug.LogWarning("Please set a camera in player components...");
#endif
        myTransform = transform;
        rb = GetComponent<Rigidbody>();
        direction = myTransform.forward;
    }

    protected virtual void Start() {
        //TODO DO SOMEWHERE ELSE ON MAIN BRANCH
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    protected virtual void Update() {
        inputs.x = playerRef.GetAxisRaw("Horizontal");
        inputs.z = playerRef.GetAxisRaw("Vertical");

        //UpdateTargetPosition();
    }

    protected virtual void FixedUpdate() {
        //Move depending on Camera rotation
        direction.x = inputs.x;
        direction.z = inputs.z;
        direction = Quaternion.AngleAxis(Camera.transform.rotation.eulerAngles.y, Vector3.up) * direction;

        //Normalize + adjust with Time.deltaTime
        Vector3 movementsNormalized = direction.normalized * (MovementSpeed * Time.deltaTime);
        movementsNormalized.y = rb.velocity.y;

        //Set
        rb.velocity = movementsNormalized;
        
        //Rotate player toward movement direction
        myTransform.rotation = Quaternion.LookRotation(myTransform.forward + movementsNormalized);
    }

    private void UpdateTargetPosition() {
        //Always start from player position
        rotationTarget = myTransform.position;
        
        //Update target position on X axis
        if (inputs.x != 0)
            rotationTarget.x += (inputs.x >= 0 ? 1 : -1 * rotationTargetOffset);


        //Reset target position to default (default = in front of player)
        Vector3 forward = myTransform.forward;
        rotationTarget.x += rotationTargetOffset * forward.x;
        rotationTarget.z += rotationTargetOffset * forward.z;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(rotationTarget, 0.1f);
    }
}