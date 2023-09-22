using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fabio.Level2project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new TimedTile", menuName = "ScriptableObjects/Tiles/Create New TimedTile")]
    public class TimedTile : TileType
    {
        [Range(0f, 3f)]
        public float Timer;
    }
}
