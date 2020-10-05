using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrap : PressurePlateComponent
{
    public ParticleSystem Fire;
    public Collider Hitbox;
    
    protected override void OnActivation() {
        base.OnActivation();
        Fire.Play();
        Hitbox.enabled = true;
    }

    protected override void OnDeactivation() {
        base.OnDeactivation();
        Fire.Stop();
        Hitbox.enabled = false;
    }
}
