using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrap : PressurePlateComponent
{
    public ParticleSystem Fire;
    public Collider Hitbox;
    private bool isEnabled = true;
    public override void Awake() {
        OnActivation += PlayVFX;

        OnDeactivation += StopVFX;
    }

    public void PlayVFX()
    {
        if (!isEnabled) return;
        Fire.Play();
        Hitbox.enabled = true;
    }

    public void StopVFX() {
        Fire.Stop();
        Hitbox.enabled = false;
    }

    public void Activate(bool enable)
    {
        isEnabled = enable;
    }
}
