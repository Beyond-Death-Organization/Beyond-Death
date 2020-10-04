using System;
using UnityEngine;

namespace Components
{
    public class TriggerCameraMove : MonoBehaviour
    {
        public float y;
        public float time;
        private void OnTriggerEnter(Collider other)
        {
            MoveOvertime moveOvertime;
            if ((moveOvertime = other.GetComponentInChildren<MoveOvertime>()) != null)
            {
                moveOvertime.Move(y, time);
            }

        }
    }
}