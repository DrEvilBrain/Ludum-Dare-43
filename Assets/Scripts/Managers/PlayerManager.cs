using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = player.GetComponent<PlayerStats>();
    }

    public void KillPlayer()
    {
        // game over
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SacrificeVitality()
    {
        playerStats.ChangeStats(playerStats.vitality);

        AfterSacrafice();
    }

    public void SacrificeStrength()
    {
        playerStats.ChangeStats(playerStats.strength);

        AfterSacrafice();
    }

    public void SacrificeDexterity()
    {
        playerStats.ChangeStats(playerStats.dexterity);

        AfterSacrafice();
    }

    public void SacrificeWisdom()
    {
        playerStats.ChangeStats(playerStats.wisdom);

        AfterSacrafice();
    }

    public void SacrificeWeapon()
    {
        // change character weapon

        AfterSacrafice();
    }

    private void AfterSacrafice()
    {
        // close sacrafice menus
        UIManager.instance.CloseAllMenus();

        // begin spawn wave
        GameManager.instance.StartSpawnWave();
    }
}
