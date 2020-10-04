#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
[ExecuteInEditMode]
public class Follow : MonoBehaviour
{
    public bool EditorFollow;
    public GameObject ToFollow;
    private Vector3 offset;
    private void Awake()
    {
        if(Application.isPlaying || EditorFollow)
            offset = transform.position - ToFollow.transform.position;
    }

    public void SetOffset()
    {
        offset = transform.position - ToFollow.transform.position;
    }

    private void Update()
    {
        if(Application.isPlaying || EditorFollow)
            transform.position = ToFollow.transform.position + offset;
    }
}
#if UNITY_EDITOR
[CustomEditor(typeof(Follow))]
public class FollowEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Follow follow = (Follow) target;
        
        DrawPropertiesExcluding(serializedObject, nameof(follow.EditorFollow));

        var temp = EditorGUILayout.Toggle(nameof(follow.EditorFollow), follow.EditorFollow);
            
        if(temp != follow.EditorFollow && temp)
            follow.SetOffset();
        follow.EditorFollow = temp;
    }
}
#endif

