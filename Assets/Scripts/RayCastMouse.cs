using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastMouse : MonoBehaviour
{
    public LayerMask layerMask; // Layer mask to filter raycast hits
    private GridBlockInfo gridBlock; // Reference to the GridBlockInfo component
    private Camera cam;
    private GridBlockInfo temp = null; // Temperory Reference to store the last selected GridBlockInfo

    void Start()
    {
        cam = Camera.main; // Get the main camera
    }

    // Update is called once per frame
    void Update()
    {
        MouseCast(); 
    }

    private void MouseCast() //Method sends a raycast from the camera to the mouse
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f,layerMask)) // Cast a ray from the camera to the mouse position
        {
            Debug.Log("Ray has hit");
            gridBlock = hit.transform.GetComponent<GridBlockInfo>();
            if(temp!=gridBlock)
            {
                if(temp!=null)
                    temp.SetActiveOff(); // Deactivate the selection indicator on the previously selected grid block
            }
            if (gridBlock != null)
            {
                gridBlock.SetActiveOn(); // Activate the selection indicator on the grid block
                temp = gridBlock; // Store the reference to the GridBlockInfo component
            }
            
        }
        else
        {
            gridBlock = null; // If no hit, set gridBlock to null
            if (temp != null)
            {
                temp.SetActiveOff(); // Deactivate the selection indicator on the previously selected grid block
                temp = null; // Clear the temporary reference
            }
        }

    }
}
