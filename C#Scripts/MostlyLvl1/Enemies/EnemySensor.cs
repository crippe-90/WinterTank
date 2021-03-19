using UnityEngine;
using System;

public class EnemySensor : MonoBehaviour {
    public ParticleSystem tankExp;
    public Transform player;
    public TextMesh hp;
    public GameManager gm;
    public AudioSource explosion;

    private int hitpoints;

    private System.Random randomDmg = new System.Random();

    void Awake () {
        hp.color = Color.green;
        hitpoints = 400;
	}

	void Update () {
        if (Vector3.Distance(transform.position, player.position) < 100f)
        {

            hp.text = "Monkey tank:" + Environment.NewLine + hitpoints.ToString() + " HP";
            if (hitpoints < 200)
            {
                if (hitpoints < 100)
                {
                    hp.color = Color.red;
                    if (hitpoints <= 0)
                    {
                        hp.text = null;
                        tankExp.Play();
                        if (explosion != null)
                        {
                            if (!explosion.isPlaying)
                            {
                                explosion.Play();
                            }
                        }
                            
                        Destroy(gameObject, 1f);
                    }
                }
                else
                {
                    hp.color = Color.yellow;
                }
            }
        }     
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Bullet"))
        {
            hitpoints-= randomDmg.Next(1,5);
        }
    }

    public string GetHp()
    {
        return hitpoints.ToString();
    }
    private void OnDestroy()
    {
        gm.DecEnemyCounter();
    }
}
