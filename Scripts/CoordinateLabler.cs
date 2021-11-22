using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabler : MonoBehaviour
{
    //use the access of is placeable to change coordinate colour
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockColor = Color.blue;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f); // orange color isn't default so we create  it using rgb values.
    //**********************************************************
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Tile waypoint; // access to our waypoints
    GridManager gridManager;

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        waypoint = GetComponentInParent<Tile>(); // we get component in parent because the waypoint is on the root of our object and the coordinate is on the root of the children.
        DisplayCoordinaties();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinaties();
            UpdateObjectName();
            label.enabled = true;
            //do something
        }
        SetLabelColor();
        ToggleLabels();
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive(); // toggling the visibility of our label.
        }
       
    }
     void SetLabelColor()
    {
        if (gridManager == null) { return; }

        Node node = gridManager.GetNode(coordinates); // if this turns out to be null our if is broken

        if (node == null) { return; }

        if (!node.isWalkable)
        {
            label.color = blockColor;
        }
        else if (node.isPath)
        {
            label.color = pathColor;
        }
        else if (node.isExplored)
        {
            label.color = exploredColor;
        }
        else
        {
            label.color = defaultColor;
        }
    
    }

    void DisplayCoordinaties()
    {
        if(gridManager == null) { return; }
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / gridManager.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.UnityGridSize);

        label.text = coordinates.x + "," + coordinates.y;
    }
    
    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
