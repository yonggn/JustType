using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubmitButton : MonoBehaviour
{
    public TMP_InputField input;
    public int wpm;

    public void StoreWPM()
    {
        wpm = int.Parse(input.text);
        PlayerPrefs.SetInt("WPM", wpm);
    }
}
