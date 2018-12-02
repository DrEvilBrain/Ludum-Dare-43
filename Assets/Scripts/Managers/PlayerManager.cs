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

    public void SacrificeStat()
    {
        // change character stats
        
    }

    public void SacrificeWeapon()
    {
        // change character weapon
    }
}
