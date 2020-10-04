using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class ChangeRotationTile : MonoBehaviour
{
    private int[] randomValue = {0, 90, 180, 270};
    // Start is called before the first frame update
    public List<Transform> Tiles;
    void Start()
    {
        foreach (var tile in Tiles)
        {
            tile.localRotation = Quaternion.Euler(0,randomValue[Random.Range(0,3)],0);
        }
    }
}
