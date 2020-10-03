using System.Collections.Generic;
using UnityEngine;

public class TransparentRenderQueue : MonoBehaviour
{
    List<GameObject> hits = new List<GameObject>();
    void FixedUpdate()
    {
        foreach (var hit in hits)
        {
            hit.SetActive(true);
        }
        hits.Clear();
        var cameraTransform = Camera.main.transform;
        Ray ray = new Ray(transform.position, cameraTransform.transform.position - transform.position);
        var raycastHits = Physics.RaycastAll(ray, Vector3.Distance(cameraTransform.position, transform.position));

        if (raycastHits.Length > 0)
        {
            foreach (var raycastHit in raycastHits)
            {
                if (raycastHit.transform != transform)
                {
                    raycastHit.transform.gameObject.SetActive(false);
                    hits.Add(raycastHit.transform.gameObject);
                }
            }
        }
    }
}
