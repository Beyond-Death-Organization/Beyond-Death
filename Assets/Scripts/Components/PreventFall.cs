using System;
using UnityEngine;

namespace Components
{
    public class PreventFall : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            Debug.Log("test");
            GameManager.Instance.NextLevel(0);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("test");
            GameManager.Instance.NextLevel(0);
        }
        
        
    }
}