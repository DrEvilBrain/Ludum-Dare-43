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

        // update UI
        UIManager.instance.vitalityNumber.text = playerStats.vitality.GetValue().ToString();
    }

    public void SacrificeStrength()
    {
        playerStats.ChangeStats(playerStats.strength);

        // update UI
        UIManager.instance.strengthNumber.text = playerStats.strength.GetValue().ToString();
    }

    public void SacrificeDexterity()
    {
        playerStats.ChangeStats(playerStats.dexterity);

        // update UI
        UIManager.instance.dexterityNumber.text = playerStats.dexterity.GetValue().ToString();
    }

    public void SacrificeWisdom()
    {
        playerStats.ChangeStats(playerStats.wisdom);

        // update UI
        UIManager.instance.wisdomNumber.text = playerStats.wisdom.GetValue().ToString();
    }

    public void SacrificeWeapon()
    {
        // change character weapon
    }

    public void AfterSacrafice()
    {
        // close sacrafice menus
        UIManager.instance.CloseAllMenus();

        // begin spawn wave
        GameManager.instance.StartSpawnWave();
    }
}
