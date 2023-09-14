using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.Unicode;

public class PCGManager : MonoBehaviour
{
    public PCGElements LevelElements;


    private Vector3 _nextPosition;
    private List<int> _probabilities = new List<int>();
    private List<GameObject> Tiles = new List<GameObject>();

    private void Start()
    {
        BuildProbabilities();
        SpawnFirstPlatform();
        GenerateLevel();
    }

    public void SpawnFirstPlatform()
    {
        SpawnPlatform(LevelElements.StartPosition, LevelElements.InitialTiles);
    }

    private void Update()
    {
        List<GameObject> remove = new List<GameObject>();
    }

    void SpawnPlatform(Vector2 pos, int length)
    {
        int yPos = Random.Range(LevelElements.MinPlatformY, LevelElements.MaxPlatformY);

        for (int i = 0; i < length; i++)
        {
            int tileIndex = _probabilities[Random.Range(0, _probabilities.Count)];
            Vector2 tilePos = pos + new Vector2(i, yPos);
            GameObject newTile = GameObject.Instantiate(LevelElements.TileTypes[tileIndex].Prefab, tilePos, Quaternion.identity);
            Tiles.Add(newTile);
            if (i == length / 2)
            {
                BoxCollider2D newCollider = newTile.AddComponent<BoxCollider2D>();
                newCollider.size = new Vector2(length, newCollider.size.y);
                if (length % 2 == 0)
                {
                    newCollider.offset = new Vector2(-0.5f, newCollider.offset.y);
                }               
            }

            //if (i % 2 == 0)
            //{
            //    GameObject newScoreObj = GameObject.Instantiate(ScoreObject, tilePos + Vector2.up, Quaternion.identity);
            //    newScoreObj.transform.SetParent(newTile.transform);
            //}
        }

        int gap = Random.Range(LevelElements.MinPlatformGap, LevelElements.MaxPlatformGap);
        _nextPosition.x += length + gap;
    }
    public void ClearPath()
    {
        for (int i = Tiles.Count - 1; i >= 0; i--)
        {
            Destroy(Tiles[i]);
        }
        Tiles.Clear();

        _nextPosition = Vector2.zero;
    }

    void BuildProbabilities()
    {
        int index = 0;
        foreach (TileType t in LevelElements.TileTypes)
        {
            for (int i = 0; i < t.Probability; i++)
            {
                _probabilities.Add(index);
            }
            index++;
        }
    }

    void GenerateLevel()
    {
        for (int i = 0; i < LevelElements.LevelLenght; i++)
        {
            SpawnPlatform(_nextPosition, Random.Range(LevelElements.MinPlatformSize, LevelElements.MaxPlatformSize));
        }
    }
}


