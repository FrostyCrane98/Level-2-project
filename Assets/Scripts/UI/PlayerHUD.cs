using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Fabio.Level2project.Entities
{
    public class PlayerHUD : MonoBehaviour
    {
        public List<GameObject> LifeIcons = new List<GameObject>();
        public TextMeshProUGUI ChronometerText;
        private float _chronometerTime;
        
        public void UpdateLives(int health)
        {
            for (int i = LifeIcons.Count - 1; i >= 0; i--)
            {
                LifeIcons[i].SetActive(health > i);
            }
        }

        public void ResetChronometer()
        {
            _chronometerTime = 0;
        }

        private void FixedUpdate()
        {
            _chronometerTime += Time.fixedDeltaTime;
            DisplayTime(_chronometerTime);
        }

        private void DisplayTime(float timeToDisplay)
        {
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            ChronometerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

         
    }
}
