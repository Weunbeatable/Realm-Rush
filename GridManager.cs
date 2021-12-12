using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;
    [Tooltip("The world Grid Size - Should Match Unity Editor Snap Settings")]
    [SerializeField] int unityGridSize = 10;
    public int UnityGridSize { get { return unityGridSize; } }

    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>(); //The key is the coordinate of each part on the grid and the value is the node object itself. 
    public Dictionary<Vector2Int, Node> Grid { get { return grid; } }

  void Awake()
    {
        CreateGrid();
    }
    public Node GetNode(Vector2Int coordinate)
    {
        if (grid.ContainsKey(coordinate))
        {// searches our dictionary and returns true or false if we find the key, then we can return the node
            return grid[coordinate];
        }
        return null;
        //return grid[coordinates] is liable to prblems where we get errors. there are gaurds to this though
    }

    public void BlockNode(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            grid[coordinates].isWalkable = false; // block nodes where that is placeable flag is false.
        }
    }

    public void ResetNode()
    {
        //loop through all nodes in our grid, set connected to null, is explored to false and is path to false.
        foreach (KeyValuePair<Vector2Int, Node> entry in grid)
        {
            entry.Value.connectedTo = null;
            entry.Value.isExplored = false;
            entry.Value.isPath = false;
        }
    }

    public Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();
        coordinates.x = Mathf.RoundToInt(position.x / unityGridSize); //taking transform position of parent and dividig by unity snap stettings
        coordinates.y = Mathf.RoundToInt(position.z / unityGridSize);

        return coordinates;
    }

    public Vector3 GetPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector3 position = new Vector3();
        position.x = coordinates.x * unityGridSize;
        position.z = coordinates.y * unityGridSize;

        return position;
    }
    void CreateGrid()
    { // nested for loop for incrementing through our grid so we can find the x value and the y value at the same time. 
     for(int x = 0; x < gridSize.x; x++)
        {
            for(int y = 0; y < gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                grid.Add(coordinates, new Node(coordinates, true));
               // Debug.Log(grid[coordinates].coordinates +  " = " + grid[coordinates].isWalkable); // logging the data from the dictionary to find areas on our grid that are walkable.  
            }
        }
    }
}
