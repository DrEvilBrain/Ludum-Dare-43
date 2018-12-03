using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int round { get; private set; }
    public int enemiesMorePerRound;
    public int enemiesToSpawn;
    public int enemiesSpawned;
    public int enemiesKilled;
    public bool stopSpawning { get; private set; }

    public Item weapon1;
    public Item weapon2;

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
        round = 0;
        StartSpawnWave();
	}

    public void StopSpawning()
    {
        stopSpawning = true;
    }

    public void NextRound()
    {
        round++;

        // generate weapons
        weapon1 = ItemManager.instance.GenerateWeapon(weapon1);
        weapon2 = ItemManager.instance.GenerateWeapon(weapon2);

        // character sacrafice menu
        UIManager.instance.OpenSacraficeMenu();
    }

    public void StartSpawnWave()
    {
        enemiesToSpawn += enemiesMorePerRound;
        enemiesSpawned = 0;
        enemiesKilled = 0;
        stopSpawning = false;
        UIManager.instance.UpdateWaveNumber(round + 1);
    }

    public void EndGame()
    {
        LevelManager.instance.FadeToLevel();
    }
}
