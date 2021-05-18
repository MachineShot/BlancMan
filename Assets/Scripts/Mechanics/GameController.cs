using Platformer.Core;
using Platformer.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This class exposes the the game model in the inspector, and ticks the
    /// simulation.
    /// </summary> 
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }
        public Vector2 lastCheckpointPos;
        public int lastCheckpointNumber;
        public int level;
        public int health;
        public int score;

        //This model field is public and can be therefore be modified in the 
        //inspector.
        //The reference actually comes from the InstanceRegister, and is shared
        //through the simulation and events. Unity will deserialize over this
        //shared reference when the scene loads, allowing the model to be
        //conveniently configured inside the inspector.
        public PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        void OnEnable()
        {
            level = SceneManager.GetActiveScene().buildIndex;
            if (SaveSystem.isScenebeingLoaded)
            {
                SaveSystem.LoadPlayer();
                model.player.gameObject.transform.position = new Vector3(SaveSystem.copyData.checkpointPos[0], SaveSystem.copyData.checkpointPos[1]);
                model.player.health.currentHP = SaveSystem.copyData.health;
                model.player.coins = SaveSystem.copyData.score;
                level = SaveSystem.copyData.level;
                //SceneManager.LoadScene(level);
                lastCheckpointPos.x = SaveSystem.copyData.checkpointPos[0];
                lastCheckpointPos.y = SaveSystem.copyData.checkpointPos[1];
                lastCheckpointNumber = SaveSystem.copyData.checkpointNumber;
            }
            Instance = this;
        }

        void OnDisable()
        {
            if (Instance == this) Instance = null;
        }

        void Update()
        {
            health = model.player.health.currentHP;
            score = model.player.coins;
            if (Instance == this) Simulation.Tick();
        }
    }
}