using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fabio.Level2project.Managers;
using Fabio.Level2project.ScriptableObjects;

namespace Fabio.Level2project.Entities
{
    public class Player : MonoBehaviour
    {
        public PlayerGameParams HealthParams;
        public int CurrentHealth { get {return _currentHealth;}}
        
        private int _currentHealth;
        private Vector2 _initialPosition;


        private void OnEnable()
        {
            _initialPosition = transform.position;
            _currentHealth = HealthParams.InitialHealth;
            EventManager.Instance.OnStart += ResetPlayer;
            EventManager.Instance.OnPlayerHit += PlayerHit;
            EventManager.Instance.OnStageClear += RespawnPlayer;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnStart -= ResetPlayer;
            EventManager.Instance.OnPlayerHit -= PlayerHit;
            EventManager.Instance.OnStageClear += RespawnPlayer;
        }

        private void FixedUpdate()
        {
            if (transform.position.y < -10f)
            {
                EventManager.Instance.PlayerHit();
            }
        }

        private void PlayerHit()
        {
            _currentHealth--;
            RespawnPlayer();

            if (_currentHealth <= 0) 
            {
                EventManager.Instance.PlayerDeath();
            }
        }

        private void ResetPlayer()
        {
            _currentHealth = HealthParams.InitialHealth;
            transform.position = _initialPosition;
        }

        private void RespawnPlayer()
        {
            transform.position = _initialPosition;
        }
    }
}
