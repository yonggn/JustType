using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Grade : MonoBehaviour
{
    public TextMeshProUGUI gradeText;

    public float waitTime=1f;

    public bool perfect;
    public bool good;
    public bool miss;

    public GameObject gameEndPanel;

    public int perfectCount=0;
    public int goodCount=0;
    public int missCount=0;

    public char finalGrade='P';

    public TextMeshProUGUI perfectScore;
    public TextMeshProUGUI goodScore;
    public TextMeshProUGUI missScore;
    public TextMeshProUGUI finalGradeText;
    public TextMeshProUGUI bpmText;

    public MusicManager musicManager;

    private void Start()
    {
        finalGrade = 'P';
        gameEndPanel.SetActive(false);
    }

    void Update()
    {
        if (perfect)
        {
            CountGrade();
            gradeText.text = "Perfect!";
            perfect = false;
            Invoke("ClearText", waitTime);
        }
        else if (good)
        {
            CountGrade();
            gradeText.text = "Good!";
            good = false;
            Invoke("ClearText", waitTime);
        }
        else if (miss)
        {
            CountGrade();
            gradeText.text = "Miss!";
            miss = false;
            Invoke("ClearText", waitTime);
        }
        
        if(LetterOnBeat.gameEnd)
        {
            gameEndPanel.SetActive(true);
            FinalGrade();
        }
    }

    public void ClearText()
    {
        gradeText.text = "";
    }

    private void CountGrade()
    {
        if (perfect)
        {
            perfectCount++;
        }
        else if (good)
        {
            goodCount++;
        }
        else if (miss)
        {
            missCount++;
        }
    }

    private void FinalGrade()
    {
        int totalHit = perfectCount + goodCount + missCount;
        if (perfectCount == totalHit)
        {
            finalGrade = 'S';
        }
        else if (perfectCount>goodCount&&perfectCount>missCount&&missCount<5)
        {
            finalGrade = 'A';
        }
        else if (goodCount>perfectCount&&goodCount>missCount)
        {
            finalGrade = 'B';
        }
        else if (goodCount > perfectCount && goodCount > missCount&&missCount<totalHit/4)
        {
            finalGrade = 'C';
        }
        else if(missCount>goodCount&&missCount>perfectCount)
        {
            finalGrade = 'F';
        }
        else
        { finalGrade = 'D'; }

        perfectScore.text="Perfect : "+ perfectCount.ToString();
        goodScore.text="Good :  "+goodCount.ToString();
        missScore.text="Miss : "+missCount.ToString();
        finalGradeText.text = finalGrade.ToString();
        bpmText.text = "BPM : "+musicManager.bpm.ToString();

        WriteLevelProgress();

    }

    public void WriteLevelProgress()
    {
        if(finalGrade=='A'||finalGrade=='B'||finalGrade=='C'||finalGrade=='S')
        {
            PlayerPrefs.SetInt("LevelCompleted", PlayerPrefs.GetInt("Level"));
            PlayerPrefs.SetInt("ShowNoti", 1);
        }
        Debug.Log(PlayerPrefs.GetInt("LevelCompleted"));
        
        // Eg now level 1 completed
        // playerprefs will have LevelCompleted 1
        // if level1 completed, means level1+2 in playable now
        // if playerprefs set int level completed,
        // then level [i] playable
    }

}
