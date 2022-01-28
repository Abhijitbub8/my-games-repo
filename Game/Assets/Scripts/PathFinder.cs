using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Waypoint endWaypoint;
   
    [SerializeField] bool isRunning = true;
    Vector2Int[] directions = { 
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.left,
        Vector2Int.right
    };

   [SerializeField] private List<Waypoint> path = new List<Waypoint>();

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
   // EnemyMovement aaa;

    
   
    
  

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            CalculatePath();
        }
        return path;
     
    }

    private void CalculatePath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
    }

    public void CreatePath()
    {
        path.Add(endWaypoint);
        endWaypoint.isPlaceble = false;
        Waypoint Previous = endWaypoint.ExploredFrom;
        while (Previous != startWaypoint)
        {
            path.Add(Previous);
            Previous.isPlaceble = false;
            Previous = Previous.ExploredFrom;
        }
        path.Add(startWaypoint);
        startWaypoint.isPlaceble = false;
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);
       


        while (queue.Count > 0 && isRunning)
        {
            var SearchCenter = queue.Dequeue();

            SearchCenter.isExplore = true;
           // print("Searching from "+ SearchCenter);
            HaltIfEndFound(SearchCenter);
            ExploreNeighbours(SearchCenter);
        }
      //  print("Pathfinding finish?");
    }

    private void HaltIfEndFound(Waypoint Searchcenter)
    {
        if (Searchcenter == endWaypoint)
        {
          // print("start and end position are same");
            isRunning = false;
          
        }
    }

    private void ExploreNeighbours(Waypoint SearchCenter)
    {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int explore = SearchCenter.GetGridpos() + direction;
           
            //print("Exploring "+ explore);
            try
            {
                QueueNewNeighbours(explore,SearchCenter);

            }
            catch 
            {
                //do nothing
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int explore,Waypoint SearchCenter)
    {
        Waypoint neighbour = grid[explore];
        neighbour.SetColor(Color.blue);
        
        if (!neighbour.isExplore)
        {
            queue.Enqueue(neighbour);
            neighbour.ExploredFrom = SearchCenter;
          
         //  print("queueing " + neighbour);
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetColor(Color.green);
        endWaypoint.SetColor(Color.red);

    }

    private void LoadBlocks()
    {
        var waypoints = GetComponentsInChildren<Waypoint>();

        

        foreach (Waypoint waypoint in waypoints)
        {
            bool isOverLapping = grid.ContainsKey(waypoint.GetGridpos());
            if (isOverLapping)
            {
           //  print("skip Overlapping " + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridpos(), waypoint);
                waypoint.SetColor(Color.magenta);
            }
        }
      //  print(grid.Count);
    }

  


        void Update()
    {
        
    }
}
