using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncherControl : Steering {
    private bool rotateLeft;
    private bool rotateRight;
    private bool rotateUp;
    private bool rotateDown;
    private Vector3 rotationY;
    private Vector3 rotationX;
    private float minXrot;
    private float maxXrot;
    private float rotationSpeed = 30f;
    private float xAngle;
	
	void Start () {
        rotationY = new Vector3(0f,rotationSpeed,0f);
        rotationX = new Vector3(rotationSpeed, 0f, 0f);
        rotateDown = false;
        rotateUp = false;
        rotateRight = false;
        rotateLeft = false;
        StartCoroutine("RotateBazooka");
        minXrot = -75f;
        maxXrot = 10f;
	}
    private void Update()
    {
        xAngle = transform.rotation.eulerAngles.x;  
    }
    #region For buttons
    public void RotateRight()
    {
        StopRotateLeft();
        rotateRight = true;
    }
    public void RotateLeft()
    {
        StopRotateRight();
        rotateLeft = true;
    }
    public void RotateUp()
    {
        StopRotateDown();
        rotateUp = true;
    }
    public void RotateDown()
    {
        StopRotateUp();
        rotateDown = true;
    }
    public void StopRotateRight()
    {
        rotateRight = false;
    }
    public void StopRotateLeft()
    {
        rotateLeft = false;
    }
    public void StopRotateUp()
    {
        rotateUp = false;
    }
    public void StopRotateDown()
    {
        rotateDown = false;
    }
    #endregion

    IEnumerator RotateBazooka()
    {
        while (true)
        {
            if (rotateUp&&(xAngle>maxXrot))
            {
                transform.Rotate(-rotationX * Time.deltaTime, Space.Self);
            }
            if (rotateDown&&(xAngle>minXrot))
            {
                transform.Rotate(rotationX * Time.deltaTime, Space.Self);
            }
            if (rotateLeft)
            {
                transform.Rotate(-rotationY * Time.deltaTime, Space.Self);
            }
            if (rotateRight)
            {
                transform.Rotate(rotationY * Time.deltaTime, Space.Self);
            }
            

            yield return new WaitForEndOfFrame();
        }
    }

}
