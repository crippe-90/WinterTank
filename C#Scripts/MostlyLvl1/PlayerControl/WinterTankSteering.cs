using System;
using System.Collections;
using UnityEngine;

public class WinterTankSteering : Steering {
    /*Rotating variables*/
    private bool goRight = false;
    private bool goLeft = false;
    private float rotationSpeed = 45f;
    Vector3 rotation;
    /*moving variables*/
    private bool moveForward = false;
    private bool moveBackward = false;
    private float forward = 10f;
    private float backward = -4f;
    private Vector3 newPosition;

    public bool gameRunning;

    public AudioSource driving;
    public AudioSource standingWithEngineRunning;

    private bool playRunning;
    private void Awake()
    {
        gameRunning = true;
        rotation = new Vector3(0f, rotationSpeed, 0f);

        //for android
        //StartCoroutine("Rotate");
        //StartCoroutine("Move");
    }

    //Used only for keyboard
    private void Update()
    {
        playRunning = false;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            playRunning = true;
            GoForward();
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            playRunning = true;
            GoBack();
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            playRunning = true;
            GoLeft();
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            playRunning = true;
            GoRight();
        }

        if (playRunning)
        {
            if (!driving.isPlaying)
            {
                standingWithEngineRunning.Stop();
                driving.Play();
            }
           
        }
        else
        {
            
            if (!standingWithEngineRunning.isPlaying)
            {
                driving.Stop();
                standingWithEngineRunning.Play();
            }
            
        }
    }

    private void GoBack()
    {
        newPosition = new Vector3(0, 0, backward);
        transform.position += transform.TransformDirection(newPosition) * Time.deltaTime;
    }

    private void GoForward()
    {
        newPosition = new Vector3(0, 0, forward);
        transform.position += transform.TransformDirection(newPosition) * Time.deltaTime;
    }

    /*Handeling moving and rotation with keyboard*/
    private void GoRight()
    {
        transform.Rotate(rotation * Time.deltaTime, Space.Self);
    }
    private void GoLeft()
    {
        transform.Rotate(-rotation * Time.deltaTime, Space.Self);
    }

    /*Handeling button presses and realeses for android*/
    public void RightButtonDown()
    {
        goRight = true;
    }
    public void LeftButtonDown()
    {
        goLeft = true;
    }
    public void LeftButtonUp()
    {
        goLeft = false;
    }
    public void RightButtonUp()
    {
        goRight = false;
    }
    public void ForwardButtonDown()
    {
        moveForward = true;
    }
    public void BackButtonDown()
    {
        moveBackward = true;
    }
    public void ForwardButtonUp()
    {
        moveForward = false;
    }
    public void BackButtonUp()
    {
        moveBackward = false;
    }

    /*Handeling moving and rotation for android*/
    IEnumerator Rotate()
    {
        while (gameRunning)
        {
            if (goRight)
            {
                goLeft = false;
                transform.Rotate(rotation*Time.deltaTime, Space.Self);
            }
            else if (goLeft)
            {
                goRight = false;
                transform.Rotate(-rotation * Time.deltaTime, Space.Self);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator Move()
    {
        while (gameRunning)
        {
            if (moveForward)
            {
                moveBackward = false;
                newPosition = new Vector3(0, 0, forward);
                transform.position += transform.TransformDirection(newPosition) * Time.deltaTime;

            }
            else if (moveBackward)
            {
                moveForward = false;
                newPosition = new Vector3(0, 0, backward);
                transform.position += transform.TransformDirection(newPosition) * Time.deltaTime;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    public override void StopMoving()
    {
        gameRunning = false;
    }
}
