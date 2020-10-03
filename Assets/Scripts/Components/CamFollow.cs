using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ObjectToStare;
    public Vector3 offSet;
    // Update is called once per frame
    void Update()
    {
        transform.position = ObjectToStare.position + offSet;
        transform.LookAt(ObjectToStare);
    }
}
