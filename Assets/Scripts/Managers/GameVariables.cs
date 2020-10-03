using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class GameVariables : MonoBehaviour, ISerializationCallbackReceiver
{
    public List<ReferenceWrapper> Wrapper = new List<ReferenceWrapper>();
    public static Dictionary<string, GameObject> References = new Dictionary<string, GameObject>();
    public void OnBeforeSerialize()
    {
        Wrapper.Clear();

        foreach (var kvp in References)
            Wrapper.Add(new ReferenceWrapper{key = kvp.Key, value = kvp.Value});
    }

    public void OnAfterDeserialize()
    {
        References = new Dictionary<string, GameObject>();

        for (int i = 0; i != Wrapper.Count; i++)
        {
            if (References.ContainsKey(Wrapper[i].key))
            {
                References.Add(Guid.NewGuid().ToString(), null);
                continue;
            }
            References.Add(string.IsNullOrEmpty(Wrapper[i].key) ? Guid.NewGuid().ToString() : Wrapper[i].key, Wrapper[i].value);
        }
    }
}
[Serializable]
public class ReferenceWrapper
{
    public string key;
    public GameObject value;
}