using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fabio.Level2project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new Obstacle", menuName = "ScriptableObjects/Obstacles/Create New Obstacle")]
    public class Obstacle : ScriptableObject
    {
        public GameObject Prefab;
        public int Probability;
    }
}
