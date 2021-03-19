using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintingText : MonoBehaviour {

    float timer;
    int index;

    public string textToPrint;
    public Text text;

    public GameObject[] objectsToActivate;

    private void Start()
    {
        timer = 0f;
        index = 0;
    }


    void Update () {
        timer += 12f*Time.deltaTime;
        
        if (index < Mathf.FloorToInt(timer))
        {
            index = Mathf.FloorToInt(timer);
            Print(textToPrint, index);
        }
    }

    private void Print(string s, int i)
    {
        if (i < s.Length)
        {
            text.text = s.Substring(0, i);
        }
        else
        {
            foreach (GameObject g in objectsToActivate)
            {
                g.SetActive(true);
            }
        }
        
    }
}
