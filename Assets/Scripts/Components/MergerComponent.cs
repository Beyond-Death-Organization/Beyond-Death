using UnityEngine;

public class MergerComponent : MonoBehaviour
{
    private void Awake()
    {
        StaticBatchingUtility.Combine(gameObject);
    }
}
