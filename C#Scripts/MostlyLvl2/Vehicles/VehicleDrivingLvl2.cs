using UnityEngine;
using System.Collections;

public class VehicleDrivingLvl2 : Steering {
    private Vector3 newPosition;
    private Vector3 direction;
    public float speed;
    private Quaternion viewDirection;
    private int turnPointCounter;
    public Transform[] turnPointList;
    private bool move;


	void Start () {
        turnPointCounter = turnPointList.Length;
        StartMovement();
    }
    
    public void ChangeFocus()
    {
        if (turnPointCounter > 0)
        {
            turnPointCounter--;
        }
        else
        {
            move = false;
        }
    }


    private IEnumerator Move()
    {
        while (move)
        {
            Aim();
            transform.position += transform.TransformDirection(new Vector3(0f,0f,speed)) * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
    private void Aim()
    {
        if (turnPointCounter>0)
        {
            newPosition = turnPointList[turnPointCounter - 1].position;
        }
        direction = (newPosition - transform.position).normalized;
        viewDirection = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, viewDirection, 3f*Time.deltaTime);
    }

    public override void StopMoving()
    {
        move = false;
    }

    public void StartMovement()
    {
        move = true;
        StartCoroutine("Move");
    }
}
