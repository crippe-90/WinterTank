using UnityEngine;

public class LevelCompleted : MonoBehaviour {
    
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            if (true)
            {
                FindObjectOfType<GameManager>().LevelCompleted();
            }
            
        }
    }
}
