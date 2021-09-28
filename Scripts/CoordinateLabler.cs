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
    [SerializeField] Color blockColor = Color.clear;
    //**********************************************************
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    waypoint waypoint; // access to our waypoints

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        waypoint = GetComponentInParent<waypoint>(); // we get component in parent because the waypoint is on the root of our object and the coordinate is on the root of the children.
        DisplayCoordinaties();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinaties();
            UpdateObjectName();
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
    private void SetLabelColor()
    {
        if (waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
            label.color = blockColor;
    }

    void DisplayCoordinaties()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = coordinates.x + "," + coordinates.y;
    }
    
    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
