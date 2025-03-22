using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PedestrianSystemController))]
public class PedestrianSystemUI : Editor
{
    public override void OnInspectorGUI()
    {
        GUILayout.Space(20);
        GUILayout.Label("Pedestrian Navigation System", new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Bold, fontSize = 24 });
        GUILayout.Space(20);

        DrawDefaultInspector();

        PedestrianSystemController pedestrianSystemController = (PedestrianSystemController)target;
        GUILayout.Space(20);
        if (GUILayout.Button("Add node to the scene"))
        {
            pedestrianSystemController.AddNode();
        }
    }
}