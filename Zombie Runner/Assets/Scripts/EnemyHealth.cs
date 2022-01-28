using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float totalHealth = 100f;


    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDamageTaken(float healthDecrement)
    {
        BroadcastMessage("EnemyGetHit");
        totalHealth = totalHealth - healthDecrement;
        if (totalHealth<=0)
        {
            if (isDead) return;
            isDead = true;
            GetComponent<Animator>().SetBool("Attack", false);
            GetComponent<Animator>().SetTrigger("Die");
           
            //   Destroy(gameObject);
        }
       
        print(totalHealth);
    }
}
