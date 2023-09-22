using Fabio.Level2project.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fabio.Level2project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new Wall", menuName = "ScriptableObjects/Obstacles/Create New Wall")]
    public class Wall : Obstacle
    {
        public int MinWallHeight, MaxWallHeight;
    }
}
