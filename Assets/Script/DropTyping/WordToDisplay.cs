using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordToDisplay : MonoBehaviour
{
    public TextMeshProUGUI wordDisplay;
    public float fallSpeed=1f;
    public GameObject destroyLine;
    public GameObject slowLine;
    public bool exceedLine;
    public static bool isSlow;
    //public static bool wordComplete = false;

    private void Start()
    {
        //wordComplete = false;
        //float randFallSpeed = Random.Range(0.5f, 1f);
        //fallSpeed = randFallSpeed;
    }

    public void SetWord(string word)
    {
        wordDisplay.text = word.ToString();
    }

    public void RemoveLetter() //remove current letter
    {
        //remove letter by 1 (next to it)
        wordDisplay.text = wordDisplay.text.Remove(0,1);
        wordDisplay.color = Color.red;
    }

    public void RemoveWord()  //remove the whole word
    {
        //wordComplete = true;
        isSlow = false;
        Destroy(gameObject);
    }

    public void RemoveTheWord(Object word)
    { 
        Destroy(word);
    }

    private void Update()
    {
        //the z value in translate is set to 1 because text mesh pro is a 3d object and need z value for the depth
        transform.Translate(0f, -fallSpeed * Time.deltaTime,0.1f);
        /*if(gameObject.transform.position.y<=destroyLine.transform.position.y)
        {
            //wordDisplay.text = "";
            isSlow = false;
            exceedLine = true;
            RemoveWord();
        }*/
        if(gameObject.transform.position.y<=slowLine.transform.position.y&&gameObject.transform.position.y>=destroyLine.transform.position.y)
        {
            isSlow = true;
            exceedLine = false;
        }

    }


}
