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

        public event Action OnPlayerHit;
        public event Action OnPlayerDeath;
        public event Action OnStageClear;
        public event Action OnPauseToggled;
        public event Action OnStart;
        public event Action OnTitleScreen;
        public event Action OnResume;
        public event Action OnGameOver;


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

        #endregion

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

        public void PlayerHit()
        {
            OnPlayerHit?.Invoke();
        }
    }
}
