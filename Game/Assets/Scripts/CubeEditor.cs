using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
   
    TextMesh textMesh;
    Vector3 GridPos;
    Waypoint waypoint;

    void Awake()
    {

        waypoint = GetComponent<Waypoint>();
       // Debug.Log("Editor causes this Awake");
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();

    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
       
       
        transform.position = new Vector3(waypoint.GetGridpos().x * gridSize, 0f,waypoint.GetGridpos().y * gridSize);
    }

    private void UpdateLabel()
    {
        int gridSize = waypoint.GetGridSize();

        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = waypoint.GetGridpos().x+ "," + waypoint.GetGridpos().y;
        textMesh.text = labelText;
        gameObject.name = labelText;

    }
}
