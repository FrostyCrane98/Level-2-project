using Fabio.Level2project.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fabio.Level2project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Level Manager Params", menuName = "ScriptableObjects/Level Manager/ Create New Level Manager Params")]
    public class LevelManagerParams : ScriptableObject
    {
        public List<PCGElements> Levels = new List<PCGElements>();
        public int NumberOfLevels;
    }
}
