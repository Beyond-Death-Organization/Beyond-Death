using System.Collections;
using UnityEngine;

namespace Components
{
    public class MoveOvertime : MonoBehaviour
    {
        public void Move(float y, float time)
        {
            StopAllCoroutines();
            StartCoroutine(MoveTimed(y, time));
        }

        IEnumerator MoveTimed(float y, float time)
        {
            float initTime = Time.time;

            while (initTime + time > Time.time)
            {
                Vector3 position = transform.localPosition;
                position.y = Mathf.Lerp(position.y, y, (Time.time - initTime) / time);
                transform.localPosition = position;
                yield return null;
            }
        }
        
        
    }
}