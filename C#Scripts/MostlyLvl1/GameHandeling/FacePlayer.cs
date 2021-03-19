
using UnityEngine;

public class FacePlayer : MonoBehaviour {
    private Vector3 direction;
    public Transform player;
    public TextMesh text;
    private Quaternion viewDirection;

	void Update () {
        if(Vector3.Distance(player.position, transform.position)< 150f)
        {
            text.text = "BASE";
            direction = (player.position - transform.position).normalized;
            viewDirection = Quaternion.LookRotation(-direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, viewDirection, 1000f * Time.deltaTime);
        }
        else
        {
            text.text = "";
        }
        
    }
}
