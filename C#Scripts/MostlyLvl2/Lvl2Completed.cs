using UnityEngine;

public class Lvl2Completed : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("GAME COMPLETED!");
            FindObjectOfType<GameManager>().LoadNextScene();
           
        }
    }
}
