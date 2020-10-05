using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateComponent : MonoBehaviour
{
    [Tooltip("Can player activate the plate")]
    public bool IsPlayerActivatable;

    [Tooltip("Can interactables (box) activate the plate")]
    public bool IsInteractableActivatable;

    [HideInInspector] public bool IsActivated;

    private ushort amountObjectsOnPressurePlate = 0;

    public delegate void EmptyDelegate();

    public EmptyDelegate OnActivation, OnDeactivation;

    private ushort AmountObjectsOnPressurePlate {
        get => amountObjectsOnPressurePlate;
        set {
            amountObjectsOnPressurePlate = value;
            if (value == 0)
                OnDeactivation?.Invoke();
            else if (value == 1)
                OnActivation?.Invoke();
        }
    }

    public virtual void Awake() {
        OnActivation += () => IsActivated = true;
        OnDeactivation += () => IsActivated = false;
        HomeMadeAwake();
    }

    protected virtual void HomeMadeAwake() { }

    private void OnTriggerEnter(Collider other) {
        if (IsInteractableActivatable)
            if (!other.TryGetComponent(out PlayerMovementComponent player))
                AmountObjectsOnPressurePlate++;

        if (IsPlayerActivatable)
            if (other.TryGetComponent(out PlayerMovementComponent player))
                AmountObjectsOnPressurePlate++;
    }

    private void OnTriggerExit(Collider other) {
        if (IsInteractableActivatable)
            if (!other.TryGetComponent(out PlayerMovementComponent player))
                AmountObjectsOnPressurePlate--;

        if (IsPlayerActivatable)
            if (other.TryGetComponent(out PlayerMovementComponent player))
                AmountObjectsOnPressurePlate--;
    }
}