using Fabio.Level2project.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;
using Fabio.Level2project.Entities;

namespace Fabio.Level2project.Managers
{
    public class GameController : MonoBehaviour
    {

        private enum eGameState
        {
            TitleScreen,
            Start,
            Idle,
            Resume,
            Pause,
            Win,
            GameOver
        }

        private eGameState State;

        private void OnEnable()
        {
            EventManager.Instance.OnPlayerDeath += OnPlayerDeath;
            EventManager.Instance.OnGameCompleted += OnGameWin;
            EventManager.Instance.OnPauseToggled += TogglePause;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnPlayerDeath -= OnPlayerDeath;
            EventManager.Instance.OnGameCompleted -= OnGameWin;
            EventManager.Instance.OnPauseToggled -= TogglePause;
        }

        private void Start()
        {
            State = eGameState.TitleScreen;
        }
        private void Update()
        {
            switch (State)
            {
                case eGameState.TitleScreen:
                    EventManager.Instance.TitleScreen();                    
                    Time.timeScale = 0;
                    break;

                case eGameState.Start:
                    EventManager.Instance.StartGame();
                    Time.timeScale = 1;
                    SetIdleState();
                    break;

                case eGameState.Pause:
                    Time.timeScale = 0;
                    break;

                case eGameState.Resume:
                    Time.timeScale = 1;
                    EventManager.Instance.ResumeGame();
                    
                    SetIdleState();
                    break;

                case eGameState.Win:
                    Time.timeScale = 0;
                    //UIController.EnableWinPanel();
                    break;

                case eGameState.GameOver:
                    EventManager.Instance.GameOver();
                    Time.timeScale = 0;
                    break;

                case eGameState.Idle:
                    break;
            }
        }



        public void ExitGame()
        {
            Application.Quit();
        }

        public void StartGame()
        {
            State = eGameState.Start;
        }

        public void Resume()
        {
            State = eGameState.Resume;
        }

        private void TogglePause()
        {
            if (State == eGameState.Idle)
            {
                State = eGameState.Pause;
            }
            else if (State == eGameState.Pause)
            {
                State = eGameState.Resume;
            }
        }

        public void QuitPlay()
        {
            State = eGameState.TitleScreen;
        }

        private void SetIdleState()
        {
            State = eGameState.Idle;
        }

        private void OnPlayerDeath()
        {
            State = eGameState.GameOver;
        }

        private void OnGameWin()
        {
            State = eGameState.Win;
        }
    }
}
