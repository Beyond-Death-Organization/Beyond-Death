using System;
using UnityEngine;

namespace Components
{
    public class PreventFall : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            GameManager.Instance.NextLevel();
        }
        
        
    }
}