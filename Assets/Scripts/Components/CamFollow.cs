using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
#if UNITY_EDITOR
using UnityEditor;
#endif
[ExecuteInEditMode]
public class CamFollow : MonoBehaviour
{
    public Transform ObjectToStare;
    public Vector3 offSet;

    public float smoothSpeed = 0.125f;

    public bool EditorFollow;
    [Conditional("UNITY_EDITOR")]
    private void Update()
    {
        #if UNITY_EDITOR
        if (!EditorApplication.isPlayingOrWillChangePlaymode && EditorFollow)
        {
            Vector3 desiredPosition = ObjectToStare.position + offSet;
            Vector3 smoothedPosition = desiredPosition;
            transform.position = smoothedPosition;
            transform.LookAt(ObjectToStare);
        }
        #endif
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = ObjectToStare.position + offSet;
        Vector3 smoothedPosition = desiredPosition;//Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(ObjectToStare);
    }
}
