using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(CameraFollow))]
public class CameraFollowEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        CameraFollow cf = (CameraFollow)target;
        if(GUILayout.Button("Set Min Can Pos"))
        {
            cf.SetMinCanPosition();
        }
        if(GUILayout.Button("Set Max Ca Pos"))
        {
            cf.SetMaxCanPosition();
        }
    }
}
