using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzi : GunBase
{

    public AudioSource pistolShot;
    public GameObject bulletPrefab;

    public override GameObject GetBulletPrefab()
    {
        return bulletPrefab;
    }

    public override void PlayAudio()
    {
        pistolShot.Play();
    }



}
