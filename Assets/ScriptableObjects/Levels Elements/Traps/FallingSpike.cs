using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fabio.Level2project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Spike", menuName = "ScriptableObjects/Traps/Create New Falling Spike")]
    public class FallingSpike : Obstacle
    {
        [Range(0f, 3f)]
        public int Damage;
        [Range(0f, 3f)]
        public float RespawnCooldown;
    }
}
