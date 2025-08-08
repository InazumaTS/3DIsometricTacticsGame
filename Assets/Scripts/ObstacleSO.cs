using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ObstacleSO : ScriptableObject
{
    public GameObject obstaclePrefab; // The prefab for the obstacle
    public Material obstacleMaterial; // The material to apply to the obstacle
    public string obstacleName; // The name of the obstacle
    public float obstacleHeight; // The height of the obstacle
}
