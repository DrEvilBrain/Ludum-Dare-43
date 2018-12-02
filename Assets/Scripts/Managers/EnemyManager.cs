using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime;
    public Transform[] spawnPoints;
    public int maxSpawns;
    private int currentSpawns;
    public bool stopSpawning { get; private set; }

    private void Start()
    {
        InvokeRepeating("Spawn", 0, spawnTime);
        stopSpawning = false;
    }

    private void Spawn()
    {
        if (currentSpawns >= maxSpawns)
        {
            Debug.Log("Stop Spawning");
            stopSpawning = true;
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        currentSpawns++;
    }

    public void NewRound(int newMaxSpawns)
    {
        currentSpawns = 0;
        maxSpawns = newMaxSpawns;
        stopSpawning = false;
    }
}
