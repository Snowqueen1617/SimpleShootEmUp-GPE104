using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    public GameObject player;
    public List<GameObject> enemyList;
    public List<GameObject> enemyPrefabList;
    public List<Transform> spawnPointList;
    public float spawnDistance;
    public GameObject playerPrefab;

    void Awake() //happens before start function
    {
        if(instance == null) //if nothing has been assigned to instance yet, assign
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //hold on to the data of this object when loading a new scene
            enemyList = new List<GameObject>();

        }
        else
        {
            Destroy(this.gameObject); //there is, destroy the game object
            UnityEngine.Debug.LogError("[GameManager] Attempted to create a second game manager: " + this.gameObject.name);
        }
    }

    void Start()
    {
        SpawnPlayer();
    }
    
    private void SpawnEnemy()
    {
        //TODO: Not yet fully implemented
        //Pick a random enemy to spawn
        GameObject enemyToSpawn = enemyPrefabList[UnityEngine.Random.Range(0, enemyPrefabList.Count)];

        //Pick a random spawn point to spawn at
        Transform spawnPoint = spawnPointList[UnityEngine.Random.Range(0, spawnPointList.Count)];

        //Pick a point within distance of spawn point to spawn at
        Vector3 randomVector = UnityEngine.Random.insideUnitCircle;
        Vector3 newPosition = spawnPoint.position + (randomVector * spawnDistance);

        //Instantiate the selected enemy at the selected position
        Instantiate(enemyToSpawn, newPosition, Quaternion.identity);
    }

    private void Update()
    {
        if(player != null)
        {
            //Spawn a new enemy if we have less than 3 enemies
            if(enemyList.Count < 3)
            {
                SpawnEnemy();
            }
        }

        if(player == null)
        {
            RespawnPlayer();
        }
    }

    private void RespawnPlayer()
    {
        player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
    }

    private void SpawnPlayer()
    {
        if(player != null)
        {

            player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        }
    }

    public void DestroyAllEnemies()
    {
        foreach(GameObject enemy in enemyList)
        {
            Destroy(enemy);
        }
    }
}
