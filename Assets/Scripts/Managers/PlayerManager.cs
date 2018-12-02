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

    public void KillPlayer()
    {
        // game over
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
