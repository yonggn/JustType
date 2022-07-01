using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public class Level
{
    public int levelCount;
    public bool playable;
    public GameObject playButton;
    public bool canCustomize;
    public AudioClip audioClip;
    public bool complete;
}

public class LevelProgress : MonoBehaviour
{

    public List<Level> level;
    public ScrollSnapRect scrollRect;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        level[0].playable = true;
        level[1].playable = true;
        level[2].playable = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(scrollRect._currentPage);
        for (int i = 0; i < level.Count; i++)
        {

            // Eg now level 1 completed
            // playerprefs will have LevelCompleted 1
            // if level1 completed, means level1+2 in playable now
            // if playerprefs set int level completed,
            // then level i+1 playable
            if(PlayerPrefs.GetInt("LevelCompleted")==i+1)  //(index =0) levelcompleted = 0+1=1; if levelcompleted = 0+1 =1
            {
                level[PlayerPrefs.GetInt("LevelCompleted")].playable = true; //level[1] is playable (level 2)
                for(int j=0;j< PlayerPrefs.GetInt("LevelCompleted"); j++)
                {
                    level[j].playable = true; //level[1] is playable (level 2)
                }
            }

            //buttons for unlocking level
            if (!level[i].playable)
            {
                level[i].playButton.SetActive(false);
            }
            else level[i].playButton.SetActive(true);
        }

        if (level[4].playable)
        {
            level[9].playable = true;
        }

        //MusicOfLevel();

        /*int currPage;
        int nextPage;
        currPage = scrollRect._currentPage;
        nextPage = currPage + 1;
        if (scrollRect._currentPage == nextPage)
        {
            MusicOfLevel();
            nextPage = currPage + 1;
        }

        Debug.Log(nextPage);*/
    }

    /*public void MusicOfLevel()
    { 
        audioSource.clip = level[scrollRect._currentPage].audioClip;
        UniBpmAnalyzer.AnalyzeBpm(audioSource.clip);
        audioSource.Play();
    }*/

    public void ToCustomizableLevel(string cLevel)
    {
        SceneManager.LoadScene(cLevel);
    }

    public void PlayLevel()
    {
        PlayerPrefs.SetInt("Level", scrollRect._currentPage+1);
        SceneManager.LoadScene("OSULike "+PlayerPrefs.GetInt("Level"));
        Debug.Log("This is level " + PlayerPrefs.GetInt("Level"));
        Debug.Log("Level completed " + PlayerPrefs.GetInt("LevelCompleted"));
    }
}
