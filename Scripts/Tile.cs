using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;

    [SerializeField] bool isPlaceable; //check if we can place a tower on that spot

    public bool IsPlaceable { get { return isPlaceable; } }  // Going to use a propery, Note the format isplaceable{} not is paceable(){}

    
    GridManager gridManager;
    PathFinder pathFinder;
    Vector2Int coordinates = new Vector2Int();
    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathFinder = FindObjectOfType<PathFinder>();
    }

    private void Start()
    {
        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if (!isPlaceable)
            {
                gridManager.BlockNode(coordinates); // by default we set is walkable to true by default so we only ned to worry about passing information when its blocked
            }
        }
    }
    private void OnMouseDown()
    {
        if (gridManager.GetNode(coordinates).isWalkable && !pathFinder.WilllBlockPath(coordinates))
        {
            bool isSuccessful = towerPrefab.CreateTower(towerPrefab, transform.position);
           if(isSuccessful)
            gridManager.BlockNode(coordinates);
            pathFinder.NotifyReceivers();
        }
    }

}
