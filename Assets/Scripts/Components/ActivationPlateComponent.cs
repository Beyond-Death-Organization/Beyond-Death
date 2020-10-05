using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivationPlateComponent : PressurePlateComponent
{
    public UnityEvent OnPlateActivated, OnPlateDeactivated;

    public override void Awake() {
        OnActivation += OnPlateActivated.Invoke;
        OnDeactivation += OnPlateDeactivated.Invoke;
    }
}
