using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinksPrefab : MonoBehaviour
{
#region Singleton

    public static LinksPrefab Instance = null;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            //GameObject.DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

#endregion
}
