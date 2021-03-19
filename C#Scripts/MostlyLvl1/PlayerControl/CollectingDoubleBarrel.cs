using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingDoubleBarrel : MonoBehaviour {
    public GameObject[] gunComponents;
    public GameObject player;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag.Equals("Player"))
        {
            Notify();
            gameObject.SetActive(false);
        }
        
    }

    private void Notify()
    {
        foreach(GameObject gun in gunComponents)
        {
            gun.SetActive(true);
        }

        DoubleBarrelGun gunScript = player.GetComponent<DoubleBarrelGun>();

        gunScript.ShotPossible();
        

    }
}
