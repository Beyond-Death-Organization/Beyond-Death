using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinksUI : MonoBehaviour
{
#region Singleton

    public static LinksUI Instance = null;

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
