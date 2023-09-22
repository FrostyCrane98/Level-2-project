using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fabio.Level2project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new Trap", menuName = "ScriptableObjects/Obstacles/Create New Trap")]
    public class Trap : Obstacle
    {
        [Range(1, 5)]
        public int Damage;
    }
}
