using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] Transform target;
   
    [SerializeField] float damage = 40f;

    PlayerHealth playerHealth;

    void Start()
    {
         playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvents()
    {
        if (target == null) { return; }

        playerHealth.EnemyHitting(damage);

      
    }

    
}
