using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    #region Singleton

    public static LevelManager instance;
    private int levelToLoad;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Animator animator;

    public void FadeToLevel()
    {
        // determine which level to load

        // main menu
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            levelToLoad = 1;
        }
        // game
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            levelToLoad = 2;

        }
        // game over
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            levelToLoad = 1;
        }
        animator.SetTrigger("FadeOut");
    }

    public void ChangeLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
