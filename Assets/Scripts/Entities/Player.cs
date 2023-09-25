using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fabio.Level2project.Managers;
using Fabio.Level2project.ScriptableObjects;
using JetBrains.Annotations;

namespace Fabio.Level2project.Entities
{
    public class Player : MonoBehaviour
    {
        public PlayerGameParams HealthParams;
        public int CurrentHealth { get {return _currentHealth;} private set {_currentHealth = value; EventManager.Instance.HealthChanged(value);}}
        
        private int _currentHealth;
        private Vector2 _initialPosition;



        private void OnEnable()
        {
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
        private void Start()
        {
            _initialPosition = transform.position;
            CurrentHealth = HealthParams.InitialHealth;
        }

        private void FixedUpdate()
        {
            if (transform.position.y < -10f)
            {
                EventManager.Instance.PlayerHit(1);
            }
        }

        private void PlayerHit(int damage)
        {
            CurrentHealth-= damage;
            RespawnPlayer();

            if (_currentHealth <= 0) 
            {
                EventManager.Instance.PlayerDeath();
            }
        }

        private void ResetPlayer()
        {
            CurrentHealth = HealthParams.InitialHealth;
            transform.position = _initialPosition;
        }

        private void RespawnPlayer()
        {
            transform.position = _initialPosition;
        }
    }
}
