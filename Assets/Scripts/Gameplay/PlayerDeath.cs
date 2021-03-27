using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player has died.
    /// </summary>
    /// <typeparam name="PlayerDeath"></typeparam>
    public class PlayerDeath : Simulation.Event<PlayerDeath>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        public override void Execute()
        {
            var player = model.player;
            if (player.health.IsAlive)
            {
                StartDeath();
                Simulation.Schedule<PlayerSpawn>(2);
            }
            else
            {
                StartDeath();
                player.StartCoroutine(restartLevel());
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        void StartDeath()
        {
            var player = model.player;
            player.health.Die();
            model.virtualCamera.m_Follow = null;
            model.virtualCamera.m_LookAt = null;
            player.controlEnabled = false;
            player.collider2d.enabled = false;
            if (player.audioSource && player.ouchAudio)
                player.audioSource.PlayOneShot(player.ouchAudio);
            player.animator.SetTrigger("hurt");
            player.animator.SetBool("dead", true);
        }

        IEnumerator restartLevel()
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}