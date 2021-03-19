using UnityEngine;

public class PlayerGrenade : MonoBehaviour {
    private float lifeTime;
    private float expTime;
    private bool hitSomething;
    private ParticleSystem exp;
    public Rigidbody grenadeBody;

    void Start () {
        hitSomething = false;
        exp = gameObject.GetComponent<ParticleSystem>();
        expTime = 1f;
        lifeTime = 5f;
	}
	void Update () {
        lifeTime-=Time.deltaTime;
        if(lifeTime <= 0)
        {
            PrepareDestruction();
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if (!hitSomething)
        {
            grenadeBody.velocity = Vector3.zero;
            hitSomething = true;
            PrepareDestruction();
            //Kill something
        }
    }

  
    private void PrepareDestruction()
    {
        exp.Play();
        Destroy(gameObject, expTime);
    }
}
