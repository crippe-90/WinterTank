using UnityEngine;

public class EnemeShooting : MonoBehaviour {
    public Rigidbody grenade;
    public ParticleSystem Sparks;
    public Transform spawnPoint;
    private Rigidbody bulletClone;
    private Quaternion dir;
    private Vector3 pos;
    private float launchPower = 10000f;

    private void Update()
    {
        pos = spawnPoint.position;
        dir = spawnPoint.rotation;
    }
    public void LaunchGrenade()
    {
        bulletClone = Instantiate(grenade, pos, dir);
        bulletClone.velocity = launchPower * spawnPoint.TransformDirection(Vector3.forward).normalized * Time.deltaTime;
        Sparks.Play();
    }
}
