using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotiManager : MonoBehaviour
{
    public GameObject notiCanvas;
    public TextMeshProUGUI notiText;
    public TextMeshProUGUI notiLvlAvailable; //level available;
    public LevelProgress levelProgress;
    public LTCanvas ltCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        //ltCanvas = gameObject.GetComponent<LTCanvas>();
        //levelProgress = gameObject.GetComponent<LevelProgress>();
        if (PlayerPrefs.GetInt("ShowNoti") == 1)
        {

            if (PlayerPrefs.GetInt("LevelCompleted")>0 || PlayerPrefs.GetInt("LevelCompleted")<4 || PlayerPrefs.GetInt("LevelCompleted")>4)
            {
                notiCanvas.SetActive(true);
                notiText.text = "New level unlocked !";
                notiLvlAvailable.text = "New level in Letter's on the Screen is available !";
            }

            if (PlayerPrefs.GetInt("LevelCompleted") ==4)
            {
                notiCanvas.SetActive(true);
                notiText.text = "New game mode available !";
                notiLvlAvailable.text = "You can play Word is Raining now. New level in Letter's on the Screen is available !";
            }
            /*if (levelProgress.level[0].playable) //when level[0] playable -> initial state, when level[1] is playable, means the level 2 is unlocked 
            {
                if (PlayerPrefs.GetInt("LevelCompleted") <=3 && PlayerPrefs.GetInt("LevelCompleted")>4)
                {
                    notiText.text = "New level unlocked !";
                    notiLvlAvailable.text = "New level in Letter's on the Screen is available !";
                }*/
            
            PlayerPrefs.SetInt("ShowNoti", 0);
        }
        if(PlayerPrefs.GetInt("LevelCompleted")==0)
        {
            notiCanvas.SetActive(true);
            notiText.text = "Hi! Welcome to JUST TYPE ! You can choose your desired game mode here.";
            notiLvlAvailable.text = "Game mode available now: Letter's on the Screen !";
        }
        //}
        Debug.Log(PlayerPrefs.GetInt("LevelCompleted"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
