using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    DeathHandler Death;
    // Start is called before the first frame update
    void Start()
    {
        Death = GetComponent<DeathHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyHitting(float damage)
    {
        if (health > 0)
        {
            health = health - damage;
            print(health);
        }
        else if (health < 0)
        {
            Death.DeathOfPlayer();
        }
    }
}
