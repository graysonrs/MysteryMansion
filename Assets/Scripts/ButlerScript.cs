using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButlerScript : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject ButlerMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Hitting f");
            if (IsPaused)
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        ButlerMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }
}
