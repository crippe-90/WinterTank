using UnityEngine.UI;
using UnityEngine;

public class HitpointsLvl2 : MonoBehaviour {
    public Text hpText;
    private int hitpoints;
    private System.Random random;

	void Start () {
        random = new System.Random();
        hitpoints = 100;
        UpdateHp();
	}
    private void Update()
    {
        if (hitpoints <= 0)
        {
            Debug.Log("Game over..");
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("Bullet"))
        {
            hitpoints = hitpoints - random.Next(1, 5);
            UpdateHp();
        }
        else if (other.tag.Equals("Grenade"))
        {
            Debug.Log("Hit by grenade");
            hitpoints = hitpoints - random.Next(3, 10);
            UpdateHp();
        }
    }
    private void UpdateHp()
    {
        hpText.text = "HP: " + hitpoints.ToString();
    }
}
