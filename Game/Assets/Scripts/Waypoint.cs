using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]public bool isExplore = false;
    [SerializeField]public bool isPlaceble = true;
    [SerializeField]public bool noTower = true;

    [SerializeField] public Waypoint ExploredFrom;
  

  
    
    Vector2Int gridPos;
    const int gridSize = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridpos()
    {
        return new Vector2Int(
              Mathf.RoundToInt(transform.position.x / gridSize) ,
              Mathf.RoundToInt(transform.position.z / gridSize) 
            );
    }

    public void SetColor(Color color)
    {
        Transform top = transform.Find("Top");
        var topMeshRenderer = top.GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceble && noTower)
            {
                print(gameObject.name + " Clicked");
                FindObjectOfType<TowerFactory>().AddTower(this);
               
            }
            else
            {
                print("Can't place there");
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
