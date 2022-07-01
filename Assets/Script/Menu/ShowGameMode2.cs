using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGameMode2 : MonoBehaviour
{
    public GameObject dropTypingButton;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("LevelCompleted")>=4)
        {
            dropTypingButton.SetActive(true);
        }
    }

}
