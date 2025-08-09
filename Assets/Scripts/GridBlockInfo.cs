using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBlockInfo : MonoBehaviour
{
    public Vector2 gridPosition = new Vector2(0,0); // imaginary grid position for this block to use for positioning in the transform space.
    public bool hasObstacle = false;
    [SerializeField]
    private GameObject gridBlockSelected; // This is the GameObject that will be activated or deactivated to indicate selection.
    [SerializeField]
    private LayerMask layerMask; // Layer mask to filter raycast hits
    [SerializeField]
    private Transform ObstacleCatch = null;
    RaycastHit hit;

    
    private void Start()
    {  
        
    }
    public void InitializeGridPosition(float gridPositionX, float gridPositionY)
    {
        gridPosition = new Vector2(gridPositionX,gridPositionY);
        if (Physics.Raycast(transform.position, Vector3.up, out hit, 100f, layerMask))
        {
            ObstacleCatch = hit.transform;
        }
        if (ObstacleCatch != null)
        {
            hasObstacle = true; // If an obstacle is detected, set hasObstacle to true
        }
        else
        {
            hasObstacle = false; // If no obstacle is detected, set hasObstacle to false
        }
    }
    public void SetActiveOff() //Turns off the selection indicator
    {
        if(gridBlockSelected.activeSelf == true)
        {
            gridBlockSelected.SetActive(false);
        }
    }
    public void SetActiveOn() //Turns on the selection indicator
    {
        if(gridBlockSelected.activeSelf == false)
        {
            gridBlockSelected.SetActive(true);
        }
    }
}
