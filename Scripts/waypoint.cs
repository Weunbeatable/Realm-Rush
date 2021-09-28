using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;

    [SerializeField] bool isPlaceable; //check if we can place a tower on that spot
   
    public bool IsPlaceable  { get { return isPlaceable; } }  // Going to use a propery, Note the format isplaceable{} not is paceable(){}
    private void OnMouseDown()
    {
        if (isPlaceable) 
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = !isPlaced;//This will prevent us from placing the same tile  mulitple times on the same location.

        }
    }

}
