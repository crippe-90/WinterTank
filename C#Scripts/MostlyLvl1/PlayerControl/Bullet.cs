using UnityEngine;

public class Bullet : MonoBehaviour {
    private float bulletLifeTime;

    private void Awake()
    {
        bulletLifeTime = 2f;
    }
    private void Update()
    {
        bulletLifeTime -= Time.deltaTime;
        if (bulletLifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
