using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GrenadeLauncher : MonoBehaviour {
    public Rigidbody grenade;
    public Transform spawnPoint;
    public Text powerText;
    private Rigidbody grenadeClone;
    private Quaternion dir;
    private Vector3 pos;
    private float grenadePower;
    private bool fireButtonDown;
    private float chargeSpeed;


    private void Start()
    {
        chargeSpeed = 30f;
        grenadePower = 0f;
        fireButtonDown = false;
    }
    private void Update()
    {
        
        pos = spawnPoint.position;
        dir = spawnPoint.rotation;  
    }
    public void FireGrenade()
    {
        if (grenadePower > 0f)
        {
            powerText.text = "";
            grenadePower = 100f * grenadePower;
            grenadeClone = Instantiate(grenade, pos, dir);
            grenadeClone.velocity = grenadePower * spawnPoint.TransformDirection(Vector3.forward).normalized * Time.deltaTime;
            grenadePower = 0f;
        }
        
    }
    public void FireButtonDown()
    {
        fireButtonDown = true;
        StartCoroutine("LoadGrenadePower");
    }
    public void FireButtonUp()
    {
        fireButtonDown = false;
        FireGrenade();
    }
    private IEnumerator LoadGrenadePower()
    {
        while (fireButtonDown)
        {
            if (grenadePower < 100f)
            {
                powerText.text = "FIRE POWER:" + Environment.NewLine + Mathf.RoundToInt(grenadePower).ToString() + "%";
                grenadePower += chargeSpeed * Time.deltaTime;
            }
            else
            {
                FireButtonUp();
            }
        
            yield return new WaitForEndOfFrame();
        }
    }
}
