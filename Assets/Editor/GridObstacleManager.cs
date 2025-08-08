using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GridObstacleManager : EditorWindow
{
    Vector2[] positionarray;

    
    [MenuItem("Tools/Grid Obstacle Creator")]
    public static void ShowWindow()
    {
        GetWindow<GridObstacleManager>("Grid Obstacle Creator");
    }

    private void OnGUI()
    {
        GUILayout.Label("Grid Obstacle Creator", EditorStyles.boldLabel);
        for(int x = 0; x < 10; x++)
        {
            GUILayout.BeginHorizontal();
            for (int y = 0; y < 10; y++)
            {
                if(GUILayout.Button($"({x},{y})",GUILayout.Width(36),GUILayout.Height(36)))
                {
                    //Debug.Log($"Button clicked at position: ({x},{y})");
                    // Here you can add functionality to create an obstacle at the specified grid position
                }
            }
            GUILayout.EndHorizontal();
        }
        //GUILayout.SelectionGrid(0,);
    }
}
