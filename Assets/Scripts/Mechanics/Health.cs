using System;
using Platformer.Gameplay;
using TMPro;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Represebts the current vital statistics of some game entity.
    /// </summary>
    public class Health : MonoBehaviour
    {
        public TextMeshProUGUI healthDisplay;

        /// <summary>
        /// The maximum hit points for the entity.
        /// </summary>
        public int maxHP = 3;

        /// <summary>
        /// Indicates if the entity should be considered 'alive'.
        /// </summary>
        public bool IsAlive => currentHP > 0;

        /// <summary>
        /// Current hit points for entity.
        /// </summary>
        public int currentHP;

        /// <summary>
        /// Increment the HP of the entity.
        /// </summary>
        public void Increment()
        {
            currentHP = Mathf.Clamp(currentHP + 1, 0, maxHP);
            healthDisplay.text = currentHP.ToString();
        }

        /// <summary>
        /// Decrement the HP of the entity. Will trigger a HealthIsZero event when
        /// current HP reaches 0.
        /// </summary>
        public void Decrement()
        {
            currentHP = Mathf.Clamp(currentHP - 1, 0, maxHP);
            healthDisplay.text = currentHP.ToString();
            if (currentHP == 0)
            {
                var ev = Schedule<HealthIsZero>();
                ev.health = this;
            }
        }

        /// <summary>
        /// Decrement the HP of the entitiy until HP reaches 0.
        /// </summary>
        public void Die()
        {
            if (currentHP > 0) Decrement();
        }

        void Awake()
        {
            currentHP = maxHP;
            healthDisplay.text = currentHP.ToString();
        }
    }
}
