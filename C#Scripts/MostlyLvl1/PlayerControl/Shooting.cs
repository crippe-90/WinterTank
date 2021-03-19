using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    public Rigidbody bullet;
    public Transform spawnPoint;
    private Rigidbody bulletClone;
    private Quaternion dir;
    private Vector3 pos;
    private float bulletPower = 50000f;

    public void GunFire()
    {
        pos = spawnPoint.position;
        dir = spawnPoint.rotation;
        bulletClone = Instantiate(bullet, pos, dir);
        bulletClone.velocity = bulletPower * spawnPoint.TransformDirection(Vector3.forward).normalized * Time.deltaTime;
    }


}
