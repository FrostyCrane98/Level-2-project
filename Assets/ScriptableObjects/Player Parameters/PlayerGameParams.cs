using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fabio.Level2project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Health Params",menuName = "ScriptableObjects/PlayerParameters/Add new Health Params")]
    public class PlayerGameParams : ScriptableObject
    {
        [Range(1, 10)]
        public int InitialHealth; 
    }
}
