using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static Unity.Collections.Unicode;

public class PCGManager : MonoBehaviour
{
    public PCGElements LevelElements;


    private Vector3 _nextPosition;
    private List<int> _probabilities = new List<int>();
    private List<GameObject> _tiles = new List<GameObject>();
    private List<GameObject> _obstacles = new List<GameObject>();

    private void Start()
    {
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
            List<int> probabilities = new List<int>();
            foreach (TileType t in LevelElements.TileTypes)
            {
                probabilities.Add(t.Probability);
            }
            int tileIndex = RollingProbabilities(probabilities);
            Vector2 tilePos = pos + new Vector2(i, yPos);
            GameObject newTile = GameObject.Instantiate(LevelElements.TileTypes[tileIndex].Prefab, tilePos, Quaternion.identity);            
            _tiles.Add(newTile);
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

    void SpawnObstacles()
    {
        List<int> probabilities = new List<int>();
        foreach (Obstacle o in LevelElements.Obstacles)
        {
            probabilities.Add(o.Probability);
        }
        probabilities.Add(LevelElements.NoObstaclesProbability);
        
        for (int i = LevelElements.InitialTiles; i < _tiles.Count; i++)
        {
            int obstacleIndex = RollingProbabilities(probabilities);
            if (obstacleIndex == probabilities.Count - 1)
            {
                continue;
            }
            else
            {
                GameObject newObstacle = GameObject.Instantiate(LevelElements.Obstacles[obstacleIndex].Prefab, _tiles[i].transform.position, Quaternion.identity);
                _obstacles.Add(newObstacle);
                switch (obstacleIndex)
                {
                    case 0:
                        
                        break;    
                    case 1:
                        Transform wallTransform = newObstacle.transform.GetChild(0);
                        wallTransform.localScale = new Vector3(wallTransform.localScale.x, Random.Range(LevelElements.MinWallHeight,LevelElements.MaxWallHeight),wallTransform.localScale.z);
                        wallTransform.position = new Vector3(wallTransform.position.x, _tiles[i].transform.position.y + wallTransform.localScale.y / 2 + 0.5f, wallTransform.position.z);
                        break;
                }                               
            }
        }
       
    }

    public void ResetLevel()
    {
        for (int i = _tiles.Count - 1; i >= 0; i--)
        {
            Destroy(_tiles[i]);
        }

        for (int i = _obstacles.Count - 1; i >= 0; i--)
        {
            Destroy(_obstacles[i]);
        }
        _tiles.Clear();
        _obstacles.Clear();
        _nextPosition = Vector2.zero;
    }

    int RollingProbabilities(List<int> probabilities)
    {
        int index = -1;
        int totalProbabilities = 0;
        foreach (int probability in probabilities)
        {
            totalProbabilities += probability;
        }

        int rollElement = Random.Range(0, totalProbabilities);

        for (int i = 0; i < probabilities.Count; i++) 
        {
            int probability = probabilities[i];
            rollElement -= probability;
            if (rollElement > 0) continue;
            return i;
        }
        return index;
    }

    void GenerateLevel()
    {
        for (int i = 0; i < LevelElements.LevelLenght; i++)
        {
            SpawnPlatform(_nextPosition, Random.Range(LevelElements.MinPlatformSize, LevelElements.MaxPlatformSize));
        }
            SpawnObstacles();
    }
}

