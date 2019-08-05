using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelCreator))]
public class LevelCreatorEditor : Editor
{



    public  override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelCreator levelCreator = (LevelCreator) target;

        if (GUILayout.Button("Generate Terrain"))
        {
            levelCreator.GenerateTerrain();
        }


        if (GUILayout.Button("Destroy Terrain"))
        {
            levelCreator.DestroyEnvironement();
        }
    }

}
