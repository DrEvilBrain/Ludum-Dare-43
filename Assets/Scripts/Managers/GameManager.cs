using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerManager playerManager;
    private EnemyManager enemyManager;

    public int round { get; private set; }
    [SerializeField] private int[] enemiesPerRound;
    public int enemiesToSpawn;
    public int enemiesSpawned;
    public int enemiesKilled;
    public bool stopSpawning { get; private set; }

    #region Singleton

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    // Use this for initialization
    void Start()
    {
        playerManager = this.GetComponent<PlayerManager>();
        enemyManager = this.GetComponent<EnemyManager>();

        Debug.Log("Start round " + round);
        round = 0;
        enemiesToSpawn = enemiesPerRound[round];
        enemiesSpawned = 0;
        enemiesKilled = 0;
        stopSpawning = false;
	}

    public void StopSpawning()
    {
        stopSpawning = true;
    }

    public void NextRound()
    {
        // character "downgrade" menu



        // start next round's enemy spawns

        round++;
        if(round > enemiesPerRound.Length)
        {
            Win();
        }
        else
        {
            Debug.Log("Start round " + round);
            enemiesToSpawn = enemiesPerRound[round];
            enemiesSpawned = 0;
            enemiesKilled = 0;
            stopSpawning = false;
        } 
    }

    private void Win()
    {
        // victory royale
        Debug.Log("A winrar is you");
    }
}
