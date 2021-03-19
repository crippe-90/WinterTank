using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBarrelGun : MonoBehaviour {
    private bool TriggerWasPulled;
    public Shooting leftGun;
    public Shooting rightGun;
    private float shootingDelay;
    public ParticleSystem rightSparks;
    public ParticleSystem leftSparks;

    public AudioSource gunShot;
    private bool shotPossible;

    private float timer;
    private void Start()
    {
        timer = 0f;
        shotPossible = false;
        shootingDelay = .2f;
        //for android
        //TriggerWasPulled = false;
        //StartCoroutine("FireLeft");
        //StartCoroutine("FireRight");
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space)&&shotPossible&&timer<=0)
        {
            timer = shootingDelay;
            Shoot();
        }
        else
        {
            StopShooting();
        }
    }

    public void ShotPossible()
    {
        shotPossible = true;
    }

    public void Shoot()
    {
        leftGun.GunFire();
        leftSparks.Play();
        rightGun.GunFire();
        rightSparks.Play();
        gunShot.Play();
        TriggerWasPulled = true;    
    }
    public void StopShooting()
    {
        rightSparks.Stop();
        leftSparks.Stop();
        TriggerWasPulled = false;
    }

    private IEnumerator FireLeft()
    {
        while (true)
        {
            if (TriggerWasPulled)
            {
                leftGun.GunFire();
                
            }
            yield return new WaitForSecondsRealtime(shootingDelay);
        }
    }
    private IEnumerator FireRight()
    {
        while (true)
        {
            if (TriggerWasPulled)
            {
                rightGun.GunFire();
            }
            yield return new WaitForSecondsRealtime(shootingDelay);
        }
    }
}
