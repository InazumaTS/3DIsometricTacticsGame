using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    [SerializeField]
    private int gridX;
    [SerializeField]
    private int gridZ;
    [SerializeField]
    private float cellHeight;
    [SerializeField]
    private float cellWidth;

    [SerializeField]
    private bool generatePath;

    private bool pathGenerated;

    private Dictionary<Vector2, Cell> cells;

    // Update is called once per frame
    void Update()
    {
        if(!pathGenerated && generatePath)
        {
            GenerateGrid();
        }
        else if(!generatePath)
        {
            pathGenerated = false;
        }
    }

    private void GenerateGrid()
    {
        for(float x =0; x < gridX; x++)
        {
            for(float z=0; z < gridZ; z++)
            {

            }
        }
    }

    private class Cell
    {
        public Vector2 position;
        public int fCost;
        public int gCost;
        public int hCost;
        public Vector2 connection;
        public bool isWall;

        public Cell(Vector2 pos)
        {
            position = pos;
        }
    }
}
