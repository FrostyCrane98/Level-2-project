using Fabio.Level2project.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Fabio.Level2project.Managers
{
    public class EventManager
    {
        #region Setup
        private static EventManager instance;
        public static EventManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventManager();
                }
                return instance;
            }
        }
        private EventManager()
        {        
        }
        #endregion

        public event Action<int> OnPlayerHit;
        public event Action OnPlayerDeath;
        public event Action OnStageClear;
        public event Action OnPauseToggled;
        public event Action OnStart;
        public event Action OnTitleScreen;
        public event Action OnResume;
        public event Action OnGameOver;
        public event Action<PCGElements> OnLevelGeneration;
        public event Action OnGameCompleted;
        public event Action<int> OnHealthChanged;


        #region GameLoop Events
        public void StartGame()
        {
            OnStart?.Invoke();
        }

        public void TitleScreen()
        {
            OnTitleScreen?.Invoke();
        }

        public void ResumeGame()
        {
            OnResume?.Invoke();
        }

        public void GameOver()
        {
            OnGameOver?.Invoke();
        }

        public void GameCompleted()
        {
            OnGameCompleted?.Invoke();
        }


        #endregion

        public void HealthChanged(int health)
        {
            OnHealthChanged?.Invoke(health);
        }
        public void LevelGeneration(PCGElements levelToGenerate)
        {
            OnLevelGeneration?.Invoke(levelToGenerate);
        }
        public void PauseToggled()
        {
            OnPauseToggled?.Invoke();
        }
        public void StageClear()
        {
            OnStageClear?.Invoke();
        }
        public void PlayerDeath()
        {
            OnPlayerDeath?.Invoke();
        }

        public void PlayerHit(int damage)
        {
            OnPlayerHit?.Invoke(damage);
        }
    }
}
