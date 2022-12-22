using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage;
    //public GameObject hitEffect;

    public void setDamage(float dmg)
    {
        this.damage = dmg;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(hitEffect, 5f);

        Unit unit = collision.gameObject.GetComponent<Unit>();
        if (unit)
        {
            unit.TakeDamage(damage);
        }


        Destroy(gameObject);
        
        //collision.
    }
}
