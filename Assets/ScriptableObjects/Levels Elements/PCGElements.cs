using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Biome", menuName = "Create New Biome")]
public class PCGElements : ScriptableObject
{
    [Header("Terrain generation parameters")]
    public List<TileType> TileTypes = new List<TileType>();

    public int InitialTiles;
    public Vector2 StartPosition;
    public int LevelLenght;
    public int MinPlatformSize, MaxPlatformSize, MinPlatformGap, MaxPlatformGap;
    public int MinPlatformY, MaxPlatformY;

    [Header("Obstacles generation parameters")]
    public List<Obstacle> Obstacles = new List<Obstacle>();
}
