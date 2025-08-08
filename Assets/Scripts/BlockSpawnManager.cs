using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] groundChoicesToPick;
    [SerializeField]
    private int gridX;
    [SerializeField]
    private int gridZ;
    [SerializeField]
    private float gridBlockOffset = 1.0f; // Offset between blocks in the grid
    [SerializeField]
    private Vector3 gridOrigin = new Vector3(0,0,0); // Origin point for the grid
    // Start is called before the first frame update
    void Start()
    {
        SpawnGrid();
    }

    // Update is called once per frame
    private void SpawnGrid()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                // Calculate the position for each block in the grid
                Vector3 spawnPosition = new Vector3(x * gridBlockOffset, 0,z * gridBlockOffset) + gridOrigin;
                
                // Randomly select a ground block from the choices
                int randomIndex = Random.Range(0, groundChoicesToPick.Length);
                GameObject selectedBlock = groundChoicesToPick[randomIndex];
                
                // Instantiate the selected block at the calculated position
                Instantiate(selectedBlock, spawnPosition, Quaternion.identity);
            }
        }
    }
}
