using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    public Vector2 playerPos;
    public bool inRange = false;
    private void FixedUpdate()
    {
        playerPos = player.transform.position;

        if (inRange)
            EnemyAimWeapon();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            inRange = false;
    }


    private void EnemyAimWeapon()
    {
        Vector2 lookDir = playerPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 0f;
        rb.rotation = angle;
    }
}
