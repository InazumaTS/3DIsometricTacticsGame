using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GridObstacleManager : EditorWindow
{
    [SerializeField]
    private ObstacleSO obstacleSO; // Reference to the ScriptableObject that holds obstacle data
    private GameObject[,] obstaclePrefabs = new GameObject[10,10]; 
    [MenuItem("Tools/Grid Obstacle Creator")]
    public static void ShowWindow()
    {
        GetWindow<GridObstacleManager>("Grid Obstacle Creator"); //Creates a new window in the Unity Editor with the title "Grid Obstacle Creator"
    }

    private void OnGUI()
    {
        GUILayout.Label("Grid Obstacle Creator", EditorStyles.boldLabel);
        for(int x = 0; x < 10; x++)
        {
            GUILayout.BeginHorizontal(); //Creates the Grid-like structure of the buttons
            for (int y = 0; y < 10; y++)
            {
                if(GUILayout.Button($"({x},{y})",GUILayout.Width(36),GUILayout.Height(36))) // Creates a button for each grid position whilst also behaving as a button
                {
                    //Debug.Log($"Button clicked at position: ({x},{y})");
                    // Here you can add functionality to create an obstacle at the specified grid position
                    ObstacleControl(x, y); // Calls the method to control obstacle creation
                }
            }
            GUILayout.EndHorizontal();
        }
        
    }

    private void ObstacleControl(float x, float y)
    {
        if(obstaclePrefabs[(int)x,(int)y] == null) // Checks if the obstacle prefab at the specified grid position is null
        {
            obstaclePrefabs[(int)x,(int)y] = Instantiate(obstacleSO.obstaclePrefab, new Vector3(x, obstacleSO.obstacleHeight, y), Quaternion.identity);
        }
        else
        {
            DestroyImmediate(obstaclePrefabs[(int)x,(int)y]); // If the obstacle prefab already exists, it destroys it
        }
    }
}
