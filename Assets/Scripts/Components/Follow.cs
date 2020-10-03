using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject ToFollow;
    private Vector3 offset;
    private void Awake()
    {
        offset = transform.position - ToFollow.transform.position;
    }

    private void Update()
    {
        transform.position = ToFollow.transform.position + offset;
    }

    // TOI TER TOU CROCHE
}
