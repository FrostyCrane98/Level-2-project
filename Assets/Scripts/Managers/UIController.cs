using Fabio.Level2project.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fabio.Level2project.Entities;

namespace Fabio.Level2project.Managers
{
    public class UIController : MonoBehaviour
    {
        public GameObject TitlePanel;
        public GameObject PausePanel;
        public GameObject WinPanel;
        public GameObject GameOverPanel;
        public PlayerHUD PlayerHUD;


        private void OnEnable()
        {
            EventManager.Instance.OnStart += StartGame;
            EventManager.Instance.OnTitleScreen += SetTitleScreen;
            EventManager.Instance.OnPauseToggled += SetPause;
            EventManager.Instance.OnResume += DisablePanels;
            EventManager.Instance.OnPlayerHit += OnPlayerHit;
            EventManager.Instance.OnGameOver += EnableGameOverPanel;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnStart -= StartGame;
            EventManager.Instance.OnTitleScreen -= SetTitleScreen;
            EventManager.Instance.OnPauseToggled -= SetPause;
            EventManager.Instance.OnResume -= DisablePanels;
            EventManager.Instance.OnPlayerHit -= OnPlayerHit;
        }

        #region Menus Management
        public void DisablePanels()
        {
            TitlePanel.SetActive(false);
            PausePanel.SetActive(false);
            WinPanel.SetActive(false);
            GameOverPanel.SetActive(false);
        }

        public void EnableTitlePanel()
        {
            DisablePanels();
            TitlePanel.SetActive(true);
        }

        public void EnablePausePanel()
        {
            DisablePanels();
            PausePanel.SetActive(true);
        }

        public void EnableWinPanel()
        {
            DisablePanels();
            WinPanel.SetActive(true);
        }

        public void EnableGameOverPanel()
        {
            DisablePanels();
            GameOverPanel.SetActive(true);
        }
        #endregion

        #region GameLoop Events
        public void StartGame()
        {
            DisablePanels();
            PlayerHUD.gameObject.SetActive(true);
            PlayerHUD.UpdateLives();
        }

        public void SetTitleScreen()
        {
            DisablePanels();
            PlayerHUD.gameObject.SetActive(false);
            EnableTitlePanel();
        }

        public void SetPause()
        {
            DisablePanels();
            EnablePausePanel();
        }
        #endregion

        public void OnPlayerHit()
        {
            PlayerHUD.UpdateLives();
        }
    }
}
