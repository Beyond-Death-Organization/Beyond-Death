using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeComponent : MonoBehaviour
{
    [Tooltip("Image to fade")] public Image Image;

    public void StartFadeIn(float timeOfFade) {
        Color initial = Image.color;
        Color final = Image.color;
        initial.a = 0;
        final.a = 1;
        StartCoroutine(Fade(Image, initial, final, timeOfFade));
    }

    public void StartFadeOut(float timeOfFade) {
        Color initial = Image.color;
        Color final = Image.color;
        initial.a = 1;
        final.a = 0;
        StartCoroutine(Fade(Image, initial, final, timeOfFade));
    }

    private IEnumerator Fade(Image obj, Color initial, Color final, float ms) {
        float time = 0;

        while (time < ms) {
            time += Time.deltaTime;
            obj.color = Color.Lerp(initial, final, time / ms);
            yield return 0;
        }

        obj.color = final;
    }
}