using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{


    [SerializeField] float movingTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));

        

    }

   
  

    IEnumerator FollowPath(List<Waypoint> path)
    {
       // print("Start Patrol");
        foreach (Waypoint waypoint in path)
        {
           // print(waypoint.name);
            transform.position = waypoint.transform.position;
           // print(transform.position);
            yield return new WaitForSeconds(movingTime);

        }
        gameObject.GetComponent<ParticleCollision>().KillEnemy();
    }
}
