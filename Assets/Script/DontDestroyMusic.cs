using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyMusic : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject.GetComponent<AudioSource>());
    }

    // Update is called once per frame
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 2)
        {
            this.gameObject.GetComponent<AudioSource>().Pause();
        }
        
    }
}
