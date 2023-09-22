using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fabio.Level2project.Managers;

namespace Fabio.Level2project.Entities
{
    public class Trap : MonoBehaviour
    {
        public Fabio.Level2project.ScriptableObjects.Trap TrapParams;
        private int DamageAmount;

        private void Start()
        {
            DamageAmount = TrapParams.Damage;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            EventManager.Instance.PlayerHit();
        }
    }
}
