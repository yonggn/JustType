using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip auclip;
    public float bpm;
    public LetterOnBeat letterOnBeat;
    public PauseMenu pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        auclip = source.clip;
        AnalyseMusic(auclip);
    }

    public void AnalyseMusic(AudioClip myMusic)
    { 
        //bpm = UniBpmAnalyzer.AnalyzeBpm(myMusic);
        /*if (bpm >= 80)
        {
            bpm /=4;
        }
        if (bpm <= 10)
        {
            bpm *= 4;
        }*/
        letterOnBeat.GetBPM(bpm);

        pauseMenu.Resume();

        //source.Play();
        source.Play();

        //Invoke("InsertNote", timeToGenerateNote);
    }

}
