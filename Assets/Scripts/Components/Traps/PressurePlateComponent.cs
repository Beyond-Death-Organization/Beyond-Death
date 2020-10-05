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

    private ushort AmountObjectsOnPressurePlate {
        get => amountObjectsOnPressurePlate;
        set {
            amountObjectsOnPressurePlate = value;
            if (value == 0)
                OnDeactivation();
            else if (value == 1)
                OnActivation();
        }
    }

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

    protected virtual void OnActivation() {
        IsActivated = true;
    }

    protected virtual void OnDeactivation() {
        IsActivated = false;
    }
}