using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public GameObject weapon1;
    public GameObject weapon2;

    public Animator animator;
    public Transform firePoint;
    private BloodGenerator bloodGenerator;

    // stats
    public float maxHealth;
    public float health;
    float health_head;
    float health_torso;
    float health_right_arm;
    float health_left_arm;
    float health_right_leg;
    float health_left_leg;

    public int penetrationLevel;

    // skills
    public int skills_Handgun;

    

    

    
    
    private void Start()
    {
        bloodGenerator = FindObjectOfType<BloodGenerator>().GetComponent<BloodGenerator>();

        health = maxHealth;
        

        //equip weapons if necessary
        
        EquipWeapons();
 

    }

    private void EquipWeapons()
    {
        if (weapon1)
        {
            GameObject gun = Instantiate(weapon1, firePoint);
            gun.GetComponent<GunBase>().SetGun(firePoint);
        }

        if (weapon2)
        {
            GameObject gun = Instantiate(weapon2, firePoint);
            gun.GetComponent<GunBase>().SetGun(firePoint);
            weapon2.SetActive(false);
        }
    }

    public void SwitchWeapons()
    {
        if (weapon1.activeInHierarchy)
        {
            weapon1.SetActive(false);
            weapon2.SetActive(true);
        }
        else if (weapon2.activeInHierarchy)
        {
            weapon1.SetActive(true);
            weapon2.SetActive(false);
        }
    }



    public void TakeDamage(float dmg)
    {
        
        
        health -= dmg;
        

        if (health <= 0)
        {
            bloodGenerator.GenerateHeavyBlood(this.transform.position);
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            Die();
            
        }
        else
        {
            bloodGenerator.GenerateBlood(this.transform.position);
            Debug.Log(dmg + " damage dealth");

        }


    }

    private void Die()
    {
        Destroy(this.gameObject);
        Debug.Log("Unit has died");
    }

    

}
