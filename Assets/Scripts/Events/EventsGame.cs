using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsGame : MonoBehaviour
{
#region Singleton

    public static EventsGame Instance = null;

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
