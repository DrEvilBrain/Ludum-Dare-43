using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartManager : MonoBehaviour
{

    #region Singleton

    public static GameStartManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
