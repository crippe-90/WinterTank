using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour {

    public Camera gpsCam;
    public Camera mainCam;
    public GameObject[] buttons;
    public GameObject machineGunButton;
    public GameObject gunPickup;
    public TextMesh gpsText;

	void Start () {
        foreach (GameObject button in buttons)
        {
            button.SetActive(true);
        }
        mainCam.enabled = true;
        gpsCam.enabled = false;
        gpsText.text = "";
	}

    public void GPSbuttonIsPressed()
    {
        foreach(GameObject b in buttons)
        {
            b.SetActive(false);
        }

        machineGunButton.SetActive(false);
        mainCam.enabled = false;
        gpsCam.enabled = true;
        gpsText.text = "BASE";
    }


    public void GPSButtonIsRealeased()
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(true);
        }
        if (!gunPickup.activeSelf)
        {
            machineGunButton.SetActive(true);
        }
        mainCam.enabled = true;
        gpsCam.enabled = false;
        gpsText.text = "";
    }


}
