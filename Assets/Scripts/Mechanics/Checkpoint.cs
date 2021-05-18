using Platformer.Mechanics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private GameController gc;
    public int checkpointNumber;
    public int level;

    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();        
        level = SceneManager.GetActiveScene().buildIndex;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(checkpointNumber > gc.lastCheckpointNumber || level > gc.level)
            {
                gc.lastCheckpointPos = transform.position;
                gc.lastCheckpointNumber = checkpointNumber;
                SaveSystem.SavePlayer(gc);
            }
        }
    }
}
