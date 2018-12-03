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

    public float GetMaxHealth()
    {
        return playerStats.maxHealth;
    }

    public float GetCurrentHealth()
    {
        return playerStats.currentHealth;
    }

    public void KillPlayer()
    {
        // game over
        SceneManager.LoadScene("Game Over");
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

    public void SacrificeWeapon(int weaponNumber)
    {
        // change character weapon
        if(weaponNumber == 1)
        {
            playerStats.ChangeWeapons(GameManager.instance.weapon1);
        }
        else if(weaponNumber == 2)
        {
            playerStats.ChangeWeapons(GameManager.instance.weapon2);
        }
    }

    public void AfterSacrafice()
    {
        // close sacrafice menus
        UIManager.instance.CloseAllMenus();

        // begin spawn wave
        GameManager.instance.StartSpawnWave();
    }
}
