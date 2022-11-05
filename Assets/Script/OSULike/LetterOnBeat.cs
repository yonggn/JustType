using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


//Insert letter on bpm
public class LetterOnBeat : MonoBehaviour
{
    public float _bpm;
    public float spawnTimer=0;
    public float timeToGenerateNote;
    public float alignTime=1;

    public GenerateLetter generateLetter;
    public MusicManager musicManager;

    public static bool gameEnd=false;

    private void Start()
    {
        gameEnd = false;
        generateLetter.RandomizeLetter();
        PauseMenu.isPaused = false;
    }
    public void GetBPM(float _Bpm)
    {
        _bpm = musicManager.bpm;
        timeToGenerateNote = 60 / _bpm; 
    }

    public void Update()
    { 
        if (!PauseMenu.isPaused && musicManager.source.isPlaying)
        {
            spawnTimer += Time.deltaTime % 60;
            
            if (spawnTimer >= timeToGenerateNote+alignTime)
            {
                spawnTimer = 0;
                InsertLetter();
            }
            
        }
        if (!musicManager.source.isPlaying&&!PauseMenu.isPaused)
        {
            gameObject.SetActive(false);
            gameEnd = true;
        }
    }

    public void InsertLetter()
    {
        if (!PauseMenu.isPaused && musicManager.source.isPlaying)
        {
            generateLetter.RandomizeLetter();
        }
    }
}