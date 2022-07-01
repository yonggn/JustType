using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word 
{
    public string word;
    private int typeIndex;
    public static bool wordTyped;
    public static bool exceed;

    WordToDisplay wordDisplay;
    //WPMCalculator wpmCalculator;

    //This function will accept parameters from WordManager to add word in list
    public Word(string _word, WordToDisplay word_display)
    {
        //generating word
        word = _word;
        typeIndex = 0;
        wordDisplay = word_display;
        wordDisplay.SetWord(word);
        //letterCount = word.Length;
    }

    public char GetNextLetter()
    {
        return word[typeIndex];
    }

    public void TypeLetter()
    {
        //increase type index
        typeIndex++;
        //startTimer = true;
        //remove from screen (or other effect?)
        wordDisplay.RemoveLetter();
    }

    
    public bool WordTyped()
    {
        wordTyped= false ;
        if (typeIndex >= word.Length)
        {
            wordTyped = true;
            //WPMCalculator.CalculateWPM();
            wordDisplay.RemoveWord();
            //WPMCalculator.timer = 0;
            Debug.Log(word + " is complete");
        }
        if(ExceedLine())
        {
            //GetNextLetter();
            wordTyped = true;
            wordDisplay.RemoveWord();
        }
        return wordTyped;
    }
    
    public bool ExceedLine()
    {
        exceed = false;
        if(wordDisplay.exceedLine)
        {
            for (int i = 0; i < word.Length - typeIndex; i++)
            { typeIndex++; }
            exceed = true;
        }
        return exceed;
    }

    public void RemoveWholeWord()
    { 
        word = "";
        wordDisplay.wordDisplay.text = "";
    }
    
}
