using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButlerScript : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public static bool PlayerIsPaused = false;
    public static bool IsPaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Hitting f");
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        PlayerIsPaused = false;
        IsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        PlayerIsPaused = true;
        IsPaused = true;
    }

}
