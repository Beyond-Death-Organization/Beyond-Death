using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivationPlateComponent : PressurePlateComponent
{
    public UnityEvent OnPlateActivated, OnPlateDeactivated;

    protected override void OnActivation() {
        base.OnActivation();
        OnPlateActivated.Invoke();
    }

    protected override void OnDeactivation() {
        base.OnDeactivation();
        OnPlateDeactivated.Invoke();
    }
}
