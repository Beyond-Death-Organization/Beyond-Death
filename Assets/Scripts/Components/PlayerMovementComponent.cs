using Rewired;
using UnityEngine;

public class PlayerMovementComponent : MonoBehaviour
{
    public float Speed;
    private Rigidbody RigidBody;
    public float WorldRotation = -45;

    private Player player;
    private int horizontalAxisId, verticalAxisId;    //TODO TO AVOID STRING COMPARISION

    private Vector3 inputs = Vector3.zero;
    private void Start() {
        player = ReInput.players.GetPlayer("Player01");
        RigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
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
            RigidBody.position += pos * Speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(pos);
        }
    }
}
