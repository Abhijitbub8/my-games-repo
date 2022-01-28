using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    [SerializeField] public int ScorePerHit = 10;
    [SerializeField] public int HitPoints = 100;
    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] ParticleSystem deathParticles;

  
   


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        Process();
        if (HitPoints <= 0)
        {
            KillEnemy();
           
        }
    }

    public void KillEnemy()
    {
        var vfx = Instantiate(deathParticles,transform.position,Quaternion.identity);
        vfx.Play();

        float destroydelay = vfx.main.duration;

        Destroy(vfx.gameObject,destroydelay);
        Destroy(gameObject);
        
    }

   

    private void Process()
    {
        HitPoints = HitPoints - ScorePerHit;
        hitParticles.Play();

    }
}
