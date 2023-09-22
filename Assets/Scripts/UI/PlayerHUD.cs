using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fabio.Level2project.Entities;

namespace Fabio.Level2project.Entities
{
    public class PlayerHUD : MonoBehaviour
    {
        public Player Player;
        public List<GameObject> LifeIcons = new List<GameObject>();
        
        
        public void UpdateLives()
        {
            for (int i = LifeIcons.Count - 1; i >= 0; i--)
            {
                LifeIcons[i].SetActive(Player.CurrentHealth > i);
            }
        }
    }
}
