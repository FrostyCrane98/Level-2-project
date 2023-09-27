using UnityEngine;
using Fabio.Level2project.Entities;
using TMPro;

namespace Fabio.Level2project.Managers
{
    public class UIController : MonoBehaviour
    {
        public GameObject TitlePanel;
        public GameObject PausePanel;
        public GameObject WinPanel;
        public GameObject GameOverPanel;
        public GameObject InstructionsPanel;
        public PlayerHUD PlayerHUD;
        public TextMeshProUGUI finalTimeText;


        private void OnEnable()
        {
            EventManager.Instance.OnStart += StartGame;
            EventManager.Instance.OnTitleScreen += SetTitleScreen;
            EventManager.Instance.OnPauseToggled += SetPause;
            EventManager.Instance.OnResume += DisablePanels;
            EventManager.Instance.OnGameOver += EnableGameOverPanel;
            EventManager.Instance.OnGameCompleted += EnableWinPanel;
            EventManager.Instance.OnHealthChanged += UpdateLives;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnStart -= StartGame;
            EventManager.Instance.OnTitleScreen -= SetTitleScreen;
            EventManager.Instance.OnPauseToggled -= SetPause;
            EventManager.Instance.OnResume -= DisablePanels;
            EventManager.Instance.OnGameOver -= EnableGameOverPanel;
            EventManager.Instance.OnGameCompleted -= EnableWinPanel;
            EventManager.Instance.OnHealthChanged -= UpdateLives;
        }

        #region Menus Management
        public void DisablePanels()
        {
            TitlePanel.SetActive(false);
            PausePanel.SetActive(false);
            WinPanel.SetActive(false);
            GameOverPanel.SetActive(false);
            InstructionsPanel.SetActive(false);
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
            SetFinalTime();
            PlayerHUD.gameObject.SetActive(false);
        }

        public void EnableGameOverPanel()
        {
            DisablePanels();
            GameOverPanel.SetActive(true);
        }

        public void EnableInstructionsPanel()
        {
            DisablePanels();
            InstructionsPanel.SetActive(true);
        }
        #endregion

        #region GameLoop Events
        public void StartGame()
        {
            DisablePanels();
            PlayerHUD.gameObject.SetActive(true);           
        }

        public void SetTitleScreen()
        {
            PlayerHUD.ResetChronometer();
            PlayerHUD.gameObject.SetActive(false);
            EnableTitlePanel();
        }

        public void SetInstructionsScreen()
        {
            EventManager.Instance.InstructionsScreen();
            EnableInstructionsPanel();
        }

        public void SetPause()
        {
            EnablePausePanel();
        }
        #endregion

        public void UpdateLives(int health)
        {
            PlayerHUD.UpdateLives(health);
        }

        private void SetFinalTime()
        {
            finalTimeText.text = PlayerHUD.ChronometerText.text;
        }
    }
}
