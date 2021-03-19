using UnityEngine;

public class Grenade : MonoBehaviour {

    private float lifeTime;
    private bool exploded;
    public ParticleSystem exp;
    public AudioSource sound;

    void Awake()
    {
        lifeTime = 5f;
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if ((lifeTime <= 0)&&!exploded)
        {
            Explode();
            
        }
    }
    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.tag.Equals("Player")||!exploded)
        {
            Explode();
        }
    }
    private void Explode()
    {
        exploded = true;
        if (sound != null)
        {
            sound.Stop();
        }
        exp.Play();
        if (!sound.isPlaying)
        {
            sound.Play();
        }
        Destroy(sound, .5f);
        Destroy(gameObject, 0.6f);
    }
}
