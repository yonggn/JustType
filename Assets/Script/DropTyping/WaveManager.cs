using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveManager : WordGenerator
{
    [System.Serializable]
    public class Wave
    {
        public int levelNow;
        public string fileName;
        public float durationOfWave;
    }

    public Wave wave;
    public float timer=0f;
    public WordManager wordManager;
    public TextMeshProUGUI nowWaveText;
    public TextMeshProUGUI newWaveInText;

    // Start is called before the first frame update
    public void Start()
    {
        waveStop = false;
        wave.levelNow = 1;
        wave.fileName = "words1.txt";
        myFilePath = Application.dataPath + "/StreamingAssets/WordFile/" + wave.fileName;
        ReadFromFile(myFilePath);
        newWaveInText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (ImportMusicDropTyping.gameStart)
        {
            if (wave.levelNow < 8)
            {
                nowWaveText.text = "Wave : " + wave.levelNow.ToString();
            }
            if (wave.levelNow == 8)
            {
                nowWaveText.text = "Wave : ∞";
            }

            //change of wave and the details are hardcoded yuppppp
            if (wave.levelNow == 1)
            {
                wave.durationOfWave = 20f;
                //timer-- until duration ends when !pause and !failed
                if (!PauseMenu.isPaused)
                {
                    timer += Time.deltaTime;

                    if (wave.durationOfWave - timer <= 10.0f)
                    {
                        newWaveInText.text = "New wave in : " + (Mathf.RoundToInt(wave.durationOfWave - timer)).ToString();
                    }
                    //if timer ends and !failed, send signal for next wave
                    if (timer >= wave.durationOfWave)
                    {
                        timer = 0;
                        waveStop = true;
                        wave.levelNow = 2; //then th egame will start second round
                        newWaveInText.text = "";
                    }
                }
            }

            if (wave.levelNow == 2)
            {
                wave.durationOfWave = 25f;
                wave.fileName = "words2.txt";
                myFilePath = Application.dataPath + "/StreamingAssets/WordFile/" + wave.fileName;
                ReadFromFile(myFilePath);
                waveStop = false;
                //timer-- until duration ends when !pause and !failed
                if (!PauseMenu.isPaused)
                {
                    timer += Time.deltaTime;

                    if (wave.durationOfWave - timer <= 10.0f)
                    {
                        newWaveInText.text = "New wave in : " + (Mathf.RoundToInt(wave.durationOfWave - timer)).ToString();
                    }

                    //if timer ends and !failed, send signal for next wave
                    if (timer >= wave.durationOfWave)
                    {
                        timer = 0;
                        waveStop = true;
                        wave.levelNow = 3; //then the game will start second round
                        newWaveInText.text = "";
                    }
                }
            }

            if (wave.levelNow == 3)
            {
                wave.durationOfWave = 30f;
                wave.fileName = "words3.txt";
                myFilePath = Application.dataPath + "/StreamingAssets/WordFile/" + wave.fileName;
                ReadFromFile(myFilePath);
                waveStop = false;
                //timer-- until duration ends when !pause and !failed
                if (!PauseMenu.isPaused)
                {
                    timer += Time.deltaTime;

                    if (wave.durationOfWave - timer <= 10.0f)
                    {
                        newWaveInText.text = "New wave in : " + (Mathf.RoundToInt(wave.durationOfWave - timer)).ToString();
                    }

                    //if timer ends and !failed, send signal for next wave
                    if (timer >= wave.durationOfWave)
                    {
                        timer = 0;
                        waveStop = true;
                        wave.levelNow = 4; //then the game will start second round
                        newWaveInText.text = "";
                    }
                }
            }
            if (wave.levelNow == 4)
            {
                wave.durationOfWave = 30f;
                wave.fileName = "words4.txt";
                myFilePath = Application.dataPath + "/StreamingAssets/WordFile/" + wave.fileName;
                ReadFromFile(myFilePath);
                waveStop = false;
                //timer-- until duration ends when !pause and !failed
                if (!PauseMenu.isPaused)
                {
                    timer += Time.deltaTime;

                    if (wave.durationOfWave - timer <= 10.0f)
                    {
                        newWaveInText.text = "New wave in : " + (Mathf.RoundToInt(wave.durationOfWave - timer)).ToString();
                    }

                    //if timer ends and !failed, send signal for next wave
                    if (timer >= wave.durationOfWave)
                    {
                        timer = 0;
                        waveStop = true;
                        wave.levelNow = 5; //then th egame will start second round
                        newWaveInText.text = "";
                    }
                }
            }
            if (wave.levelNow == 5)
            {
                wave.durationOfWave = 35f;
                wave.fileName = "words5.txt";
                myFilePath = Application.dataPath + "/StreamingAssets/WordFile/" + wave.fileName;
                ReadFromFile(myFilePath);
                waveStop = false;
                //timer-- until duration ends when !pause and !failed
                if (!PauseMenu.isPaused)
                {
                    timer += Time.deltaTime;

                    if (wave.durationOfWave - timer <= 10.0f)
                    {
                        newWaveInText.text = "New wave in : " + (Mathf.RoundToInt(wave.durationOfWave - timer)).ToString();
                    }

                    //if timer ends and !failed, send signal for next wave
                    if (timer >= wave.durationOfWave)
                    {
                        timer = 0;
                        waveStop = true;
                        wave.levelNow = 6; //then the game will start second round
                        newWaveInText.text = "";
                    }
                }
            }
            if (wave.levelNow == 6)
            {
                wave.durationOfWave = 35f;
                wave.fileName = "words6.txt";
                myFilePath = Application.dataPath + "/StreamingAssets/WordFile/" + wave.fileName;
                ReadFromFile(myFilePath);
                waveStop = false;
                //timer-- until duration ends when !pause and !failed
                if (!PauseMenu.isPaused)
                {
                    timer += Time.deltaTime;

                    if (wave.durationOfWave - timer <= 10.0f)
                    {
                        newWaveInText.text = "New wave in : " + (Mathf.RoundToInt(wave.durationOfWave - timer)).ToString();
                    }

                    //if timer ends and !failed, send signal for next wave
                    if (timer >= wave.durationOfWave)
                    {
                        timer = 0;
                        waveStop = true;
                        wave.levelNow = 7; //then th egame will start second round
                        newWaveInText.text = "";
                    }
                }
            }
            if (wave.levelNow == 7)
            {
                wave.durationOfWave = 35;
                wave.fileName = "words7.txt";
                myFilePath = Application.dataPath + "/StreamingAssets/WordFile/" + wave.fileName;
                ReadFromFile(myFilePath);
                waveStop = false;
                //timer-- until duration ends when !pause and !failed
                if (!PauseMenu.isPaused)
                {
                    timer += Time.deltaTime;

                    if (wave.durationOfWave - timer <= 10.0f)
                    {
                        newWaveInText.text = "New wave in : " + (Mathf.RoundToInt(wave.durationOfWave - timer)).ToString();
                    }

                    //if timer ends and !failed, send signal for next wave
                    if (timer >= wave.durationOfWave)
                    {
                        timer = 0;
                        waveStop = true;
                        wave.levelNow = 8; //then the game will start second round
                        newWaveInText.text = "";
                    }
                }
            }
            if (wave.levelNow == 8)
            {
                wave.fileName = "words.txt";
                myFilePath = Application.dataPath + "/StreamingAssets/WordFile/" + wave.fileName;
                ReadFromFile(myFilePath);
                waveStop = false;
                //timer-- until duration ends when !pause and !failed
                if (!PauseMenu.isPaused)
                {
                    timer += Time.deltaTime;
                    newWaveInText.text = "";
                }
            }
        }
    }
}
