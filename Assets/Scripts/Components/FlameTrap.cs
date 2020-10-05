using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrap : PressurePlateComponent
{
    public ParticleSystem Fire;
    
    protected override void OnActivation() {
        base.OnActivation();
        Fire.Play();
    }

    protected override void OnDeactivation() {
        base.OnDeactivation();
        Fire.Stop();
    }
}
