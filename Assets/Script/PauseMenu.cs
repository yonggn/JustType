using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused = false;
    public static bool isPlaying = true;

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                /*if (isPaused)
                {
                    Resume();
                }
                else
                {*/
                    Pause();
                //}

            }
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Resume()
    { 
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        AudioListener.pause = false;
        isPlaying = true;
    }

    public void QuitGame(string sceneName)
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        LetterOnBeat.gameEnd = true;
        SceneManager.LoadScene(sceneName);
    }
}
