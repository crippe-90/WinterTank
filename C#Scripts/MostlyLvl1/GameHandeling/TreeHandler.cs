using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHandler : MonoBehaviour {

    public ParticleSystem exp;
    private int hp;
    private void Start()
    {
        hp = 200;
    }
    private void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject, 1f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Enemies"))
        {
            Destroy(gameObject);
        }
        if (collision.collider.tag.Equals("Grenade"))
        {
            Destroy(gameObject);
        }
        if (collision.collider.tag.Equals("Bullet"))
        {
            hp--;
        }

    }
    private void OnDestroy()
    {
        exp.Play();
    }
}
