using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAimWeapon : MonoBehaviour
{
    public Transform aimTransform;
    public EnemyMovement movement;
    Vector3 playerPos;



    private void FixedUpdate()
    {
        playerPos = movement.playerPos;
            
        if(movement.inRange)
            AimWeapon();
        
    }

    private void AimWeapon()
    {
        Vector3 aimDirection = (playerPos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }
}
