using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropTypeGrade : MonoBehaviour
{
    public TextMeshProUGUI gradeText;
    public float waitTime=1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Word.wordTyped&&!WordToDisplay.isSlow)
        {
            gradeText.text = "Perfect !";
            Invoke("ClearText", waitTime);
        }
        else if(Word.wordTyped&&WordToDisplay.isSlow)
        {
            Debug.Log("nice");
            gradeText.text = "Nice !";
            Invoke("ClearText", waitTime);
        }
    }

    public void ClearText()
    {
        gradeText.text = "";
        Word.wordTyped = false;
        WordToDisplay.isSlow = false;
    }
}
