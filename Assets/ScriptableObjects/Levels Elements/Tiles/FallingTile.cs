using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fabio.Level2project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New FallingTile", menuName = "ScriptableObjects/Tiles/Create Falling Tile")]
    public class FallingTile : TileType
    {
        [Range(0.2f, 2f)]
        public float Timer;
    }
}

