using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused=false;
    private bool isPlaying = true;

    public NotesGenerator noteGenerator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying && !isPaused)
        {
            if (Input.GetButtonDown("Pause"))
            {
                pauseMenu.SetActive(true);
                Paused();
            }
        }
        if(isPaused&&!isPlaying)
        {
            pauseMenu.SetActive(false);
            Resume();
        }
    }

    public void Paused()
    {
        Time.timeScale = 0;
        noteGenerator.source.Pause();
        isPaused = true;
        isPlaying = false;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        noteGenerator.source.PlayDelayed(0.5f);
        isPaused = false;
        isPlaying = true;
;    }
}
