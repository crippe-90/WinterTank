using UnityEngine;
using System.Collections;

public class PrepareForBattle : MonoBehaviour {

    public GameObject enemyController;
    public GameObject[] enemies;
    GameObject closestEnemy;
    int enemyCounter;

    public float distanceToStopForEnemy;
    private bool inBattle;

	void Start ()
    {
        inBattle = false;
        enemyCounter = GetAmountOfEnemies(); 
        SetFocusOnClosestEnemy();
	}

	private void SetFocusOnClosestEnemy()
    {
        if (enemyCounter > 0)
        {
            closestEnemy = enemies[enemyCounter-1];
        }
    }

	void Update ()
    {
        if (!inBattle)
        {
            if (Vector3.Distance(closestEnemy.transform.position, transform.position) < distanceToStopForEnemy)
            {
                StartCoroutine("InBattle");
            }
        }
	}

    private int GetAmountOfEnemies()
    {
        return enemyController.transform.childCount;
    }

    private void StartDriving()
    {
        
    }

    private IEnumerator InBattle()
    {
        inBattle = true;
        FindObjectOfType<VehicleDrivingLvl2>().StopMoving();

        while (inBattle)
        {
            if (GetAmountOfEnemies() < enemyCounter)
            {
                inBattle = false;
                enemyCounter = GetAmountOfEnemies();
                FindObjectOfType<VehicleDrivingLvl2>().StartMovement();
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
