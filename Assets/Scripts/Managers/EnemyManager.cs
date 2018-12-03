using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime;
    public Transform[] spawnPoints;

    #region Singleton

    public static EnemyManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    private void Start()
    {
        InvokeRepeating("Spawn", 0, spawnTime);
    }

    private void Spawn()
    {
        if (GameManager.instance.enemiesSpawned >= GameManager.instance.enemiesToSpawn)
        {
            GameManager.instance.StopSpawning();
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        GameManager.instance.enemiesSpawned++;
    }

    public void EnemyDied()
    {
        GameManager.instance.enemiesKilled++;

        // if round is cleared
        if(GameManager.instance.enemiesKilled >= GameManager.instance.enemiesToSpawn)
        {
            GameManager.instance.NextRound();
        }
    }
}
