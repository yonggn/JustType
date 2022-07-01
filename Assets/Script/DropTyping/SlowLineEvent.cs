using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class SlowLineEvent : MonoBehaviour
{
    public bool isSlow = false;

    public AudioSource audioSource;
    public AudioMixer audioMixer;

    public float initTime;
    private float timer;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI slowDownHint;
    public GameObject loseScreen;
    public bool isLose = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        WordToDisplay.isSlow = false;
        isSlow=false;
        timer = initTime;
        loseScreen.SetActive(false);
        SpeedUp();
        
        //audioMixer = audioSource.outputAudioMixerGroup;
    }

    // Update is called once per frame
    void Update()
    {
        if (WordToDisplay.isSlow)
        {
            //Debug.Log("is slow");
            isSlow = true;
            SlowDown();
        }
        else
        {
            isSlow = false;
            SpeedUp();
        }
        if(timer<=0)
        { 
            isLose = true;
            timerText.text = "";
            slowDownHint.text = "";
            loseScreen.SetActive(true);
            Time.timeScale = 0;
        }

    }

    public void SlowDown()
    {
        audioSource.pitch = 0.6f; //because it will affect the pitch and speed
        audioMixer.SetFloat("Pitch of pitch shifter", 1 / audioSource.pitch); //this way, we can allow the speed to be slown, but the pitch will maintain
        timer-=Time.deltaTime%60;
        timerText.text = "Time until fail mission : " + timer.ToString();
        slowDownHint.text = "Hurry up eliminate the words before the time's up";
    }

    public void SpeedUp()
    {
        audioSource.pitch = 1f;
        audioMixer.SetFloat("Pitch of pitch shifter", 1 / audioSource.pitch);
        timer = initTime;
        timerText.text = "";
        slowDownHint.text = "";
    }
}
