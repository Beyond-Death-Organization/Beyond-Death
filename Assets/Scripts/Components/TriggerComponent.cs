using System;
using UnityEngine;
using UnityEngine.Events;

public class TriggerComponent : MonoBehaviour
{
    public UnityEvent onTriggerEnter = new UnityEvent();
    public UnityEvent onTriggerExit = new UnityEvent();
    public UnityEvent onCollisionEnter = new UnityEvent();
    public UnityEvent onCollisionExit = new UnityEvent();
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");
        onTriggerEnter?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        onTriggerExit?.Invoke();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("test");
        onCollisionEnter?.Invoke();
    }

    private void OnCollisionExit(Collision other)
    {
        onCollisionExit?.Invoke();
    }
}
