using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private bool startGame = false;

    public GameObject startScreenCanvas;
    public GameObject canvas1;

    private void Start()
    {
        startScreenCanvas.SetActive(true);
        canvas1.SetActive(false);
    }

    public void Update()
    {
        Invoke("StartGame", 3.0f);
    }

    public void StartGame()
    {
        if (Input.anyKeyDown && !startGame)
        {
            startGame = true;
            canvas1.SetActive(true);
            startScreenCanvas.SetActive(false);
        }
    }

    public void ShowCanvas(GameObject canvasToShow)
    { 
       canvasToShow.SetActive(true);
       // transform.LeanScale(Vector2.one, 0.8f);
    }

    public void HideCanvas(GameObject canvasToHide)
    {
        
        canvasToHide.SetActive(false);
        //transform.LeanScale(Vector2.zero, 1f);
    }

}
