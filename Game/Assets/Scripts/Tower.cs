using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToMove;
   
    [SerializeField] ParticleSystem projectileemission;
    [SerializeField] float attackRange = 100f;

    public Waypoint baseWaypoint;

     Transform targetEnemy;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
       objectToMove.LookAt(targetEnemy, Vector3.up);
        SetClosestEnemy();
        if (targetEnemy)
        {
            objectToMove.LookAt(targetEnemy, Vector3.up);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetClosestEnemy()
    {

        var sceneEnemies = FindObjectsOfType<EnemyMovement>();

        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyMovement enemy in sceneEnemies)
        {
            closestEnemy = GetClosestEnemy(closestEnemy,enemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosestEnemy(Transform transform1, Transform transform2)
    {
        float distanceToenemy1 = Vector3.Distance(transform1.transform.position, gameObject.transform.position);
        float distanceToenemy2 = Vector3.Distance(transform2.transform.position, gameObject.transform.position);

        if (distanceToenemy2 < distanceToenemy1)
        {
            return transform2;
        }
      
            return transform1;
        
    }

    private void Shoot(bool isActive)
    {
        var emission = projectileemission.emission;
        emission.enabled = isActive;
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
       
        if (distanceToEnemy<=attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);        
        }
    }
}
