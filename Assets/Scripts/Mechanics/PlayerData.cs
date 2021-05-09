using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int health;
    public int score;
    public float[] checkpointPos;
    public int checkpointNumber;

    public PlayerData(GameController gc)
    {
        level = gc.level;
        health = gc.health;
        score = gc.score;
        checkpointPos = new float[2];
        checkpointPos[0] = gc.lastCheckpointPos.x;
        checkpointPos[1] = gc.lastCheckpointPos.y;
        checkpointNumber = gc.lastCheckpointNumber;
    }
}
