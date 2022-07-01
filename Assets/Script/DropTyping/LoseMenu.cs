using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{

    public SlowLineEvent slowLineEvent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        slowLineEvent.isLose = false;
        slowLineEvent.isSlow = false;
        WordToDisplay.isSlow = false;
    }

    public void BackToMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
