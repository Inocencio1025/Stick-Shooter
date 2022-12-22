using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodGenerator : MonoBehaviour
{

    public GameObject[] bloodstains;
    public GameObject[] heavyBloodstains;
    
    

    
    public void GenerateBlood(Vector3 position)
    {
        // create blood object
        int randomIndex = Random.Range(0, bloodstains.Length);
        GameObject blood = Instantiate(bloodstains[randomIndex], GetComponentInParent<Transform>());

        // sets position 
        blood.transform.position = position;
    }

    public void GenerateHeavyBlood(Vector3 position)
    {
        // create blood object
        int randomIndex = Random.Range(0, heavyBloodstains.Length);
        GameObject blood = Instantiate(heavyBloodstains[randomIndex], GetComponentInParent<Transform>());

        // sets position 
        blood.transform.position = position;
    }
}
