using UnityEngine;
using UnityEngine.UI;

public class WinterTankSensors : MonoBehaviour {
    public Text hp;
    private int hitpoints;
    private int halfHitpoints;
    private int quarterHitpoints;
    private float positiveCriticalAngle;
    private float negativeCriticalAngle;

    private System.Random randomDmg = new System.Random();

    private void Awake()
    {
        hitpoints = 100;
        halfHitpoints = hitpoints / 2;
        quarterHitpoints = hitpoints / 4;


        positiveCriticalAngle = 90f;
        negativeCriticalAngle = 270f;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Grenade"))
        {
            hitpoints-= randomDmg.Next(1,20);
        }
    }

    void Update ()
    {
        hp.text = "HP: " + hitpoints.ToString(); 
        if(hitpoints <= halfHitpoints)
        {
            if(hitpoints <= quarterHitpoints)
            {
                hp.color = Color.red;
            }
            else
            {
                hp.color = Color.yellow;
            }
        }
       
        if((transform.eulerAngles.z > positiveCriticalAngle)&&(transform.eulerAngles.z < negativeCriticalAngle)||
            (transform.eulerAngles.x > positiveCriticalAngle) && (transform.eulerAngles.x < negativeCriticalAngle)||
            hitpoints<=0)
        {
            hitpoints = 0;
            FindObjectOfType<GameManager>().GameOver();
        }
      
	}
}
