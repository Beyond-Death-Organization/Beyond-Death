using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform ObjectToStare;
    public Vector3 offSet;

    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        Vector3 desiredPosition = ObjectToStare.position + offSet;
        Vector3 smoothedPosition = Vector3.Slerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(ObjectToStare);
    }
}
