using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFadeComponent : MonoBehaviour
{
    public static Dictionary<int, ObjectFadeComponent> Objects = new Dictionary<int, ObjectFadeComponent>();

    public float FadeInDelay, FadeOutDelay;
    public AnimationCurve FadeInCurve, FadeOutCurve;

    private List<Material> materials = new List<Material>();
    private bool isFadingIn, isFadingOut;

    private bool isFading;
    private float timeStartFade, timeEndFade;

    private void Awake() {
        Objects.Add(transform.GetInstanceID(), this);
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer r in renderers) {
            foreach (Material mat in r.materials) {
                materials.Add(mat);
            }
        }
    }

    private void Update() {
        if (isFadingIn)
            foreach (Material material in materials) {
                FadeMat(material, FadeInCurve,  timeEndFade - timeStartFade * Time.deltaTime);
                timeStartFade += Time.deltaTime;
            }
        else if (isFadingOut)
            foreach (Material material in materials) {
                FadeMat(material, FadeOutCurve, timeEndFade - timeStartFade * Time.deltaTime);
                timeStartFade += Time.deltaTime;
            }

        if (isFading && Time.time >= timeEndFade) {
            isFading = false;
            if (isFadingIn) {
                isFadingIn = false;
                SetMaterialsOpaque();
            }
            if (isFadingOut)
                isFadingOut = false;
        }
    }

    public void FadeOut() {
        isFading = true;
        isFadingOut = true;
        isFadingIn = false;
        timeStartFade = 0;
        SetMaterialsTransparent();
    }

    public void FadeIn() {
        isFading = true;
        isFadingIn = true;
        isFadingOut = false;
    }

    private void SetMaterialsTransparent() {
        foreach (Material material in materials)
            material.ToFadeMode();
    }

    private void SetMaterialsOpaque() {
        foreach (Material material in materials)
            material.ToOpaqueMode();
    }

    private void FadeMat(Material mat, AnimationCurve curve, float time) {
        Color c = mat.color;
        c.a = curve.Evaluate(time);
        mat.color = c;
    }
}