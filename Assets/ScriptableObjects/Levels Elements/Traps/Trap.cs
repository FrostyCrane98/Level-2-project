using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fabio.Level2project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new Spikes", menuName = "ScriptableObjects/Traps/Create New Spikes")]
    public class Trap : Obstacle
    {
        [Range(1, 5)]
        public int Damage;
    }
}
