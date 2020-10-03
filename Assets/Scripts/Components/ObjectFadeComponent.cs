using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFadeComponent : MonoBehaviour
{
    private Material[] materials;

    private void Awake() {
        materials = GetComponent<Renderer>().materials;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.P))
            FadeOut();
        if(Input.GetKeyDown(KeyCode.O))
            FadeIn();
    }

    private void FadeOut() {
        SetMaterialsTransparent();
        LeanTween.alpha(gameObject, 0.5f, 1f);
    }

    private void FadeIn() {
        LeanTween.alpha(gameObject, 1f, 1f).setOnComplete(() => { SetMaterialsOpaque(); });
    }

    private void SetMaterialsTransparent() {
#if UNITY_EDITOR
        Debug.Log("Fade");
#endif
        foreach (Material mat in materials) {
            mat.SetFloat("_Mode", 2);
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mat.SetInt("_ZWrite", 0);
            mat.DisableKeyword("_ALPHATEST_ON");
            mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.EnableKeyword("_ALPHABLEND_ON");
            mat.renderQueue = 3000;
        }
    }

    private void SetMaterialsOpaque() {
#if UNITY_EDITOR
        Debug.Log("Opaque");
#endif
        foreach (Material mat in materials) {
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
            mat.SetInt("_ZWrite", 1);
            mat.DisableKeyword("_ALPHATEST_ON");
            mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.DisableKeyword("_ALPHABLEND_ON");
            mat.renderQueue = -1;
        }
    }
}
