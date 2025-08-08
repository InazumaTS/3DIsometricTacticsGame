using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBlockInfo : MonoBehaviour
{
    private Vector2 gridPosition = new Vector2(0,0); // imaginary grid position for this block to use for positioning in the transform space.
    [SerializeField]
    private GameObject gridBlockSelected; // This is the GameObject that will be activated or deactivated to indicate selection.
    

    public void InitializeGridPosition(float gridPositionX, float gridPositionY)
    {
        gridPosition = new Vector2(gridPositionX,gridPositionY);
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
