using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SnapPointMaker))]
public class SnapPointEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        SnapPointMaker snapPointMaker = (SnapPointMaker)target;
        if (GUILayout.Button("Add Snap Points"))
        {
            snapPointMaker.GrabVerticesAssignSnaps();
        }
    }
}
