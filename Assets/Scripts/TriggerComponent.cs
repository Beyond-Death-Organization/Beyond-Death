using UnityEngine;
using UnityEngine.Events;

public class TriggerComponent : MonoBehaviour
{
    public UnityEvent OnEnter = new UnityEvent();
    public UnityEvent OnExit = new UnityEvent();
    private void OnTriggerEnter(Collider other)
    {
        OnEnter?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        OnExit?.Invoke();
    }
}
