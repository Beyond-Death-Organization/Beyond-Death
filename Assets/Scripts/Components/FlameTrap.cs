using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrap : PressurePlateComponent
{
    public ParticleSystem Fire;
    public Collider Hitbox;

    public override void Awake() {
        OnActivation += PlayVFX;

        OnDeactivation += StopVFX;
    }

    public void PlayVFX() {
        Fire.Play();
        Hitbox.enabled = true;
    }

    public void StopVFX() {
        Fire.Stop();
        Hitbox.enabled = false;
    }
}
