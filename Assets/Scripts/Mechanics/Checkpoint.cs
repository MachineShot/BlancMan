using Platformer.Mechanics;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameController gc;
    public int checkpointNumber;

    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && checkpointNumber > gc.lastCheckpointNumber)
        {
            gc.lastCheckpointPos = transform.position;
            gc.lastCheckpointNumber = checkpointNumber;
            SaveSystem.SavePlayer(gc);
        }
    }
}
