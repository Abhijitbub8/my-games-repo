using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement Enemy;
    [SerializeField] Transform Enemies;
   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator FollowPath()
    {
        while (true)
        {
            var enemies = Instantiate(Enemy,transform.position,Quaternion.identity);
            enemies.transform.parent = Enemies;
          //print("Spawning");
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    }
