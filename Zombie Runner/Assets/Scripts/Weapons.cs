using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float healthDecrement = 20f;
    [SerializeField] ParticleSystem particleSystem;
    [SerializeField] GameObject hitEffects;
    [SerializeField] Ammo ammo;
    [SerializeField] AmmoType ammotype;
    [SerializeField] float waitToShoot = 1f;

    bool canShoot = true;

    // int AmmoCount; 
    private void OnEnable()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {

            //  Shoot();
            StartCoroutine(Shoot());

            // print(AmmoCount);
        }

    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammo.GetAmmo(ammotype) > 0)
        {
            MuzzleFlash();
            ProcessRaycast();
            ammo.ReduceAmmo(ammotype);
        }
        yield return new WaitForSeconds(waitToShoot);
        canShoot = true;
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            HitParticles(hit);
            print(hit.transform.name);
            //   if (hit.transform.name == "Enemy")
            //   {
            try
            {
                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                //  FindObjectOfType<EnemyAI>().BroadcastMessage("EnemyGetHit");
                target.OnDamageTaken(healthDecrement);
            } catch (Exception e)
            {
                print("Exception Handled");
            }
          //  }
        }
        else
        {
            return;
        }
    }

    private void HitParticles(RaycastHit hit)
    {
        GameObject impactParticles = Instantiate(hitEffects,hit.point,Quaternion.identity);
        Destroy(impactParticles,1f);
       
    }

    private void MuzzleFlash()
    {
        particleSystem.Play();
    }
}
