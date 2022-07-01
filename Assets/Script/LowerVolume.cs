using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerVolume : MonoBehaviour
{
    public AudioSource auSource;
    public GameObject[] whenToActiveVoice;

    // Start is called before the first frame update
    void Start()
    {
        /*if(DontDestroyMusic.gotMusic)
        {
            auSource.Stop();
        }
        else
        {
            auSource.Play();
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < whenToActiveVoice.Length; i++)
        {
            if (whenToActiveVoice[i].activeInHierarchy)
            {
                auSource.volume = 1f;
            }
            else
            {
                auSource.volume = 0;
            }
        }
    }
}
