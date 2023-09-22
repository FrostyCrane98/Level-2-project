using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fabio.Level2project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new TileType", menuName = "ScriptableObjects/Tiles/Create New TileType")]
    public class TileType : ScriptableObject
    {    
        public GameObject Prefab;
        public int Probability;
}
}