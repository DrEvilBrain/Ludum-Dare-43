using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime;
    public Transform[] spawnPoints;
    public int[] enemiesPerRound;
    [SerializeField] private int roundNumber;
    [SerializeField] private int maxSpawns;
    [SerializeField] private int currentSpawns;
    [SerializeField] private int currentKilled;
    [SerializeField] public bool stopSpawning { get; private set; }

    #region Singleton

    public static EnemyManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    private void Start()
    {
        Debug.Log("Start round " + roundNumber);
        InvokeRepeating("Spawn", 0, spawnTime);
        stopSpawning = false;
        roundNumber = 0;
        maxSpawns = enemiesPerRound[roundNumber];
        currentSpawns = 0;
        currentKilled = 0;
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

    public void EnemyDied()
    {
        currentKilled++;

        if(currentKilled >= maxSpawns)
        {
            roundNumber++;
            NewRound(enemiesPerRound[roundNumber]);
        }
    }

    public void NewRound(int newMaxSpawns)
    {
        Debug.Log("Start round " + roundNumber);
        currentSpawns = 0;
        maxSpawns = newMaxSpawns;
        currentKilled = 0;
        stopSpawning = false;
    }
}
