using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fabio.Level2project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new Default Tile", menuName = "ScriptableObjects/Tiles/Create New Default Tyle")]
    public class TileType : ScriptableObject
    {    
        public GameObject Prefab;
        public int Probability;
}
}