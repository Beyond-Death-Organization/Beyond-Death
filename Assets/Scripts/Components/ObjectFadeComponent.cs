using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFadeComponent : MonoBehaviour
{
    public static Dictionary<int, ObjectFadeComponent> Objects = new Dictionary<int, ObjectFadeComponent>();

    private List<Material> materials = new List<Material>();

    private Coroutine currentCoroutine;

    private float timeAt = -1;

    private void Awake() {
        Objects.Add(transform.GetInstanceID(), this);
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer r in renderers) {
            foreach (Material mat in r.materials) {
                materials.Add(mat);
            }
        }
    }

    public void Fade(bool isFadingIn, AnimationCurve curve, float delay) {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        foreach (Material material in materials) {
            if (!isFadingIn)
                material.ToFadeMode();
        }

        currentCoroutine = StartCoroutine(FadeObject(isFadingIn, curve, delay));
    }

    private IEnumerator FadeObject(bool isFadingIn, AnimationCurve curve, float delay) {
        float time = 0;

        if (timeAt != -1)
            time = 1 - timeAt;

        while (time < delay) {
            time += Time.deltaTime;
            foreach (Material material in materials) {
                Color c = material.color;
                c.a = curve.Evaluate(time / delay);
                material.color = c;
            }

            timeAt = time / delay;
            yield return 0;
        }

        foreach (Material material in materials) {
            Color c = material.color;
            c.a = curve.Evaluate(1);
            material.color = c;

            if (isFadingIn)
                material.ToOpaqueMode();
        }

        timeAt = -1;
    }
}