using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer : MonoBehaviour
{
    public float timeForNext = 4f;
    public float timer = 0f;
    public WordManager wordManager;


    private void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        if (ImportMusicDropTyping.gameStart)
        {
            if (Time.time >= timer)
            {
                wordManager.AddWord();
                timer = Time.time + timeForNext;
                //timeForNext *= 0.99f;
                /*if (WordToDisplay.isSlow)
                    timeForNext = 4f;
                else timeForNext *= .99f;*/

            }
        }  
    }
}
