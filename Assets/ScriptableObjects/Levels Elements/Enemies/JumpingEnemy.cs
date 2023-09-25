using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fabio.Level2project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Jumping Enemy", menuName = "ScriptableObjects/Enemies/Jumping Enemy")]
    public class JumpingEnemy : Obstacle
    {
        [Range(0, 3)]
        public int Damage;
        [Range(0, 100)]
        public int JumpForce;
        [Range(0f, 5f)]
        public float JumpingTimer;
    }
}
