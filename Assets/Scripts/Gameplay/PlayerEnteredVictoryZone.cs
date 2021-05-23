using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.Gameplay
{

    /// <summary>
    /// This event is triggered when the player character enters a trigger with a VictoryZone component.
    /// </summary>
    /// <typeparam name="PlayerEnteredVictoryZone"></typeparam>
    public class PlayerEnteredVictoryZone : Simulation.Event<PlayerEnteredVictoryZone>
    {
        public VictoryZone victoryZone;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            model.player.animator.SetTrigger("victory");
            model.player.controlEnabled = false;
            model.player.StartCoroutine(Wait(2f));
        }

        IEnumerator Wait(float length)
        {
            Debug.Log("Starting new level...");
            yield return new WaitForSeconds(length);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}