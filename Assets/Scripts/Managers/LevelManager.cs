using Fabio.Level2project.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fabio.Level2project.Managers
{
    public class LevelManager : MonoBehaviour
    {
        public LevelManagerParams LevelManagerParams;
        private int _currentLevel = 1;

        private void OnEnable()
        {
            EventManager.Instance.OnStart += GenerateLevel;
            EventManager.Instance.OnStageClear += GenerateLevel;
        }
        private void OnDisable()
        {
            EventManager.Instance.OnStart -= GenerateLevel;
            EventManager.Instance.OnStageClear -= GenerateLevel;
        }
        private void GenerateLevel()
        {
            if (_currentLevel > LevelManagerParams.NumberOfLevels)
            {
                EventManager.Instance.GameCompleted();
            }
            else
            {
                PCGElements levelToGenerate = LevelManagerParams.Levels[Random.Range(0, LevelManagerParams.Levels.Count)];
                EventManager.Instance.LevelGeneration(levelToGenerate);
                _currentLevel++;
            }
        }
    }
}
