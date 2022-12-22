using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunBase : MonoBehaviour
{

    
    public Transform firePoint;
    public float bulletForce;
    

    // uses damage after level calculation
    public float BaseDamage;
    private float calculatedDamage;

    public int ammoSize;
    public int ammoMaxSize; 

    // Rate in seconds
    public float fireRate;
    public float reloadRate;

    public bool isReady;

    
    public void SetGun(Transform firePoint)
    {
        calculatedDamage = BaseDamage;
        this.firePoint = firePoint;
    }


    public void Shoot()
    {
        if (!isReady)
            return;


        //Shoot effects
        PlayAudio();

        //creates bullet and sets damage
        GameObject bullet = Instantiate(GetBulletPrefab(), firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().setDamage(calculatedDamage);

        //shoots actual bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);

        ammoSize--;
        isReady = false;


        if (!gunIsEmpty())
        {
            StartCoroutine(Cooldown());
        }
        else
        {
            StartCoroutine(Reload());
        }

        
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(fireRate);
        isReady = true;
    }

    public IEnumerator Reload()
    {
        ammoSize = ammoMaxSize;
        yield return new WaitForSeconds(reloadRate);
        isReady = true;
    }

    private bool gunIsEmpty()
    {
        if (ammoSize <= 0)
            return true;
        else
            return false;
    }

    

    public abstract void PlayAudio();
    public abstract GameObject GetBulletPrefab();

}
