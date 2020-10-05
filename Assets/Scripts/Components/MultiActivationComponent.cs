using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultiActivationComponent : MonoBehaviour
{
    public UnityEvent OnPlatesActivated;
    public List<PressurePlateComponent> Plates;
    
    private int amountPlateActivated;
    public int AmountPlateActivated {
        get => amountPlateActivated;
        set {
            amountPlateActivated = value;
            if(value == Plates.Count)
                OnPlatesActivated.Invoke();
        }
    }

    private void Awake() {
        foreach (PressurePlateComponent plate in Plates) {
            plate.OnActivation += () => { AmountPlateActivated++; };
            plate.OnDeactivation += () => { AmountPlateActivated--; };
        }
    }
}
