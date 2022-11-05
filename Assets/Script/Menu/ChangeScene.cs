using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeTheScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void FirstPlay(string sceneToKnowWPM)
    {
        if(PlayerPrefs.GetInt("LevelCompleted")<=0)
        {
            SceneManager.LoadScene(sceneToKnowWPM);
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
