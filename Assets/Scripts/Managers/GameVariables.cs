using UnityEngine;
using UnityEngine.Playables;
using System;
using System.Collections.Generic;

public class GameVariables : MonoBehaviour, ISerializationCallbackReceiver
{
#region Singleton

    public static GameVariables Instance = null;

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

    [Header("Player")] public PlayerMovementComponent Player;
    public Animator PlayerAnimtor;

    public PlayableDirector Timeline_Totem_Track01, Timeline_Totem_Track02, Timeline_Totem_Track03;
    public PlayableDirector
        Timeline_PlayerJumpOffTombeau,
        Timeline_PlayerPickupTotem,
        Timeline_PlayerDrown,
        Timeline_PlayerSpiked,
        Timeline_PlayerDarted,
        Timeline_PlayerKilled;

    [Header("UI")] public Animator CameraFadeAnimator;

    [HideInInspector] public TrapComponent LastTrapActivatedByPlayer;

    [Header("Wrapper")] public List<ReferenceWrapper> Wrapper = new List<ReferenceWrapper>();
    public static Dictionary<string, GameObject> References = new Dictionary<string, GameObject>();

    public void OnBeforeSerialize() {
        Wrapper.Clear();

        foreach (var kvp in References)
            Wrapper.Add(new ReferenceWrapper {key = kvp.Key, value = kvp.Value});
    }

    public void OnAfterDeserialize() {
        References = new Dictionary<string, GameObject>();

        for (int i = 0; i != Wrapper.Count; i++) {
            if (References.ContainsKey(Wrapper[i].key)) {
                References.Add(Guid.NewGuid().ToString(), null);
                continue;
            }

            References.Add(string.IsNullOrEmpty(Wrapper[i].key) ? Guid.NewGuid().ToString() : Wrapper[i].key,
                Wrapper[i].value);
        }
    }
}

[Serializable]
public class ReferenceWrapper
{
    public string key;
    public GameObject value;
}