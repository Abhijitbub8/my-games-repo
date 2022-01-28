using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] public int towerLimit = 5;
    [SerializeField] public Tower newTower;
    [SerializeField] Transform newTowerParent;

    Queue<Tower> queue = new Queue<Tower>();
    public void AddTower(Waypoint baseWaypoint)
    {
       

        if (queue.Count<towerLimit)
        {
            InstanstiateTower(baseWaypoint);
        }
        else
        {
            MoveTowers(baseWaypoint);

            //   print("Limit Exceeded");
        }
    }

    private void InstanstiateTower(Waypoint baseWaypoint)
    {
        var addtower = Instantiate(newTower, baseWaypoint.transform.position, Quaternion.identity);
        addtower.transform.parent = newTowerParent;
        baseWaypoint.noTower = false;

        addtower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceble = false;

        queue.Enqueue(addtower);
    }
    private void MoveTowers(Waypoint newBaseWaypoint)
    {
        var oldTower = queue.Dequeue();

        oldTower.baseWaypoint.isPlaceble = true;
        newBaseWaypoint.isPlaceble = false;
        oldTower.baseWaypoint = newBaseWaypoint;

        oldTower.transform.position = newBaseWaypoint.transform.position;

        queue.Enqueue(oldTower);
    }

    
}
