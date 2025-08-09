using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour, AI
{
    [SerializeField]
    private float movementSpeed = 7f;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private RayCastMouse rayCastMouse; // Reference to the RayCastMouse component for mouse raycasting
    private RaycastHit hit;
    private GridBlockInfo gridBlockInfo;
    Vector2 startPosition;
    Vector2 currentPosition;
    Vector2 possiblePosition;
    Vector2 bestPosition;
    Vector2 endPosition;
    int gCost;
    int hCost;
    int fCost;
    int bestFCost = 1000;
    private int adjacentMoveCounter = 0;
    private int maxAdjacentMoveCounter = 4;


    // Start is called before the first frame update
    private void Start()
    {
        startPosition = new Vector2(transform.position.x, transform.position.z);
        currentPosition = startPosition;
        bestPosition = currentPosition;
        endPosition = currentPosition;
    }

    public int AdjacentMovementCounter()
    {
        return adjacentMoveCounter;
    }

    public int MaxAdjacentMovementCounter()
    {
        return maxAdjacentMoveCounter;
    }
    public void AdjacentMoveResetCounter()
    {
        adjacentMoveCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, bestPosition.x, Time.deltaTime * movementSpeed), transform.position.y, Mathf.Lerp(transform.position.z, bestPosition.y, Time.deltaTime * movementSpeed));
        if (Mathf.Abs(transform.position.x - bestPosition.x) < 0.001 && Mathf.Abs(transform.position.z - bestPosition.y) < 0.001)
        {
            transform.position = new Vector3(bestPosition.x, transform.position.y, bestPosition.y);
            currentPosition = bestPosition;
            adjacentMoveCounter++;
            

        }
        if (adjacentMoveCounter >= maxAdjacentMoveCounter)
        {
            endPosition = currentPosition;
            
        }
        if (currentPosition != endPosition)
        {
            bestFCost = 1000;
            Pathway(endPosition);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            bestFCost = 1000;
            rayCastMouse.isMoving = false; // Reset isMoving to false when the player reaches the end position
            
        }
    }
    public void Pathway(Vector2 endPosition)
    {
        this.endPosition = endPosition;
        float DistanceX;
        float DistanceZ;
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                possiblePosition = currentPosition + new Vector2(x, y);
                if (Physics.Raycast(new Vector3(possiblePosition.x, transform.position.y, possiblePosition.y), Vector3.down, out hit, 100f, layerMask))
                {
                    gridBlockInfo = hit.transform.GetComponent<GridBlockInfo>();//If neighbouring raycast, has obstacle. it will not check for fcost;
                    if (gridBlockInfo.hasObstacle)
                    {
                        continue;
                    }
                }
                if (x == 0 && y == 0)
                    continue;
                

                DistanceX = ((Mathf.Abs(currentPosition.x - possiblePosition.x)) * (Mathf.Abs(currentPosition.x - possiblePosition.x))) * 10;
                DistanceZ = ((Mathf.Abs(currentPosition.y - possiblePosition.y)) * (Mathf.Abs(currentPosition.y - possiblePosition.y))) * 10;
                gCost = (int)Mathf.Sqrt(DistanceX * DistanceX + DistanceZ * DistanceZ);
                DistanceX = ((Mathf.Abs(endPosition.x - possiblePosition.x)) * (Mathf.Abs(endPosition.x - possiblePosition.x))) * 10;
                DistanceZ = ((Mathf.Abs(endPosition.y - possiblePosition.y)) * (Mathf.Abs(endPosition.y - possiblePosition.y))) * 10;
                hCost = (int)Mathf.Sqrt(DistanceX * DistanceX + DistanceZ * DistanceZ);
                fCost = hCost + gCost;
                
                if (fCost < bestFCost)
                {
                    bestFCost = fCost;
                    bestPosition = possiblePosition;
                 
                }
            }
        }
    }
}
