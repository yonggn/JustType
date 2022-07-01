using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesGenerator : MonoBehaviour
{
    public GameObject[] noteSprite = new GameObject[3];
    //public float speed = 0.1f;
    public float bpm=100;
    public float spawnTimer=0f;
    float timeToGenerateNote;
    public AudioSource source;
    public AudioClip clip;

    public void Start()
    {
        AnalyseMusic(clip);
    }

    public void AnalyseMusic(AudioClip myMusic)
    {
        bpm = UniBpmAnalyzer.AnalyzeBpm(myMusic);
        if(bpm >=120)
        {
            bpm/= 3;
        }
        if(bpm<=10)
        {
            bpm *= 3;
        }
        timeToGenerateNote = 60 / bpm;
        source.Play();
        //Invoke("InsertNote", timeToGenerateNote);
    }

    public void Update()
    {
        spawnTimer += Time.deltaTime%60;
        if(spawnTimer>=60/bpm)
        {
            Invoke("InsertNote", timeToGenerateNote -10 );
            spawnTimer = 0;
        }
        if(!source.isPlaying)
        {
            gameObject.SetActive(false);
        }
    }

    public void InsertNote()
    {
        int toSpawn;
        toSpawn = Random.Range(0, noteSprite.Length);
        Instantiate(noteSprite[toSpawn]);
    }
}
