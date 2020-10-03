using System;
using System.Collections.Generic;
using UnityEngine;

public class TransparentRenderQueue : MonoBehaviour
{
    private Transform camera;
    private int environnementFadeableLayer;

    private List<ObjectFadeComponent> currentHits = new List<ObjectFadeComponent>();
    private List<ObjectFadeComponent> previousHits = new List<ObjectFadeComponent>();
    private List<ObjectFadeComponent> toRemove = new List<ObjectFadeComponent>();
    

    private void Awake() {
        camera = Camera.main?.transform;
        environnementFadeableLayer = ~LayerMask.NameToLayer("EnvironnementFadeable");
    }

    void FixedUpdate() {
        currentHits.Clear();

        TryGetHits(out RaycastHit[] hits);

        foreach (RaycastHit hit in hits) {
            //Make sure it didnt touch itself
            if (hit.transform != transform) {
                int id = hit.transform.GetInstanceID();
                if(ObjectFadeComponent.Objects.ContainsKey(id))
                    currentHits.Add(ObjectFadeComponent.Objects[id]);
            }
        }

        //Fade in previous objects that aren't in front of the player anymore
        foreach (ObjectFadeComponent objFadeCompo in previousHits) {
            if (!currentHits.Contains(objFadeCompo)) {
                objFadeCompo.FadeIn();
                toRemove.Add(objFadeCompo);
            }
        }

        //Remove previous hits
        foreach (ObjectFadeComponent obj in toRemove) {
            previousHits.Remove(obj);
        }
        toRemove.Clear();
        
        //Fade out objects in front of player
        foreach (ObjectFadeComponent objFadeCompo in currentHits) {
            if (!previousHits.Contains(objFadeCompo)) {
                previousHits.Add(objFadeCompo);
                objFadeCompo.FadeOut();
            }
        }
    }

    private bool TryGetHits(out RaycastHit[] hits) {
        Ray ray = new Ray(transform.position, camera.position - transform.position);
        hits = Physics.RaycastAll(ray, Vector3.Distance(camera.position, transform.position), environnementFadeableLayer);

        return hits.Length > 0;
    }
}