using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public EnemeShooting grenadeLauncher;
    private float lookRadius = 100f;
    private float backRadius = 25f;
    private float shootRadius = 40f;

    private float grenadeChargeTime = 5f;

    private float rotationSpeed = 3f;
    private float speed = 2f;
    private float rewindSpeed = -2f;

    private bool move;
    private bool goBack;
    private bool shotPossible;

    private float distance;
    private Vector3 direction;
    
    private Quaternion viewDirection;

    public Transform player;

    private void Start()
    {
        StartCoroutine("Move");
        StartCoroutine("Rewind");
        StartCoroutine("Shoot");
        move = false;
        shotPossible = false;
        goBack = false;
    }
    private void Update()
    {
        
        distance = Vector3.Distance(player.position, transform.position);

        if (distance < lookRadius)
        {
            AimAtPlayer();
            move = true;

            if (distance < shootRadius)
            {
                shotPossible = true;
                move = false;

                    if(distance < backRadius)
                    {
                        goBack = true;
                        shotPossible = false;
                    }
                    else
                    {
                        shotPossible = true;
                        goBack = false;
                    }
                }
            else
            {
                shotPossible = false;
            }
        }
      
        else
        {
            move = false;
        }
        
       
    }

    private void AimAtPlayer()
    {
        direction = (player.position - transform.position).normalized;
        viewDirection = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, viewDirection, Time.deltaTime*rotationSpeed);
    }
    private void GoAwayFromPlayer()
    {
        direction = -(player.position - transform.position).normalized;
        viewDirection = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, viewDirection, Time.deltaTime * rotationSpeed);
    }
    private IEnumerator Move()
    {
        while (true)
        {
            if (move)
            {
                if (distance > backRadius)
                {
                    transform.position += transform.TransformDirection(new Vector3(0f, 0f, speed)) * Time.deltaTime;
                }
           
            }
            yield return new WaitForEndOfFrame();
        }

    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            if (shotPossible)
            {
                grenadeLauncher.LaunchGrenade();
            }
            yield return new WaitForSecondsRealtime(grenadeChargeTime);
        }
    }
    
    private IEnumerator Rewind()
    {
        while (true)
        {
            if (goBack)
            {
                transform.position += transform.TransformDirection(new Vector3(0f, 0f, rewindSpeed)) * Time.deltaTime;
            }
            yield return new WaitForEndOfFrame();
        }

    }
}

