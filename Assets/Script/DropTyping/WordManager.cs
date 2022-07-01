using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordManager : MonoBehaviour
{
    public List<Word> words;
    public bool hasActiveWord;
    private Word activeWord;
    public WordSpawner wordSpawner;
    WordToDisplay wordDisplay;
    public SlowLineEvent slowLine;
    //public GameObject wordPrefab;
    private TextMeshProUGUI wordText;

    private void Start()
    {
        slowLine.isLose = false;
        hasActiveWord = false;
    }
    private void Update()
    {
        if (slowLine.isLose)
        {
            hasActiveWord = false;
            for(int i=0;i<words.Count;i++)
            {
                words[i].RemoveWholeWord();
            }

        }
        foreach (char letter in Input.inputString)
        {
            TypeLetter(letter);
        }
    }
    //when add new word, get word display function
    //This func is called when time to generate new word hits
    public void AddWord()
    {
        if (!WordGenerator.waveStop && ImportMusicDropTyping.gameStart)
        {
            Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());
            words.Add(word);
        }

    }

    public void TypeLetter(char letter)
    {
        if (hasActiveWord)
        {
            //Check if letter was next and remove from the word
            if (activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
            }
        }
        else
        {
            foreach (Word word in words)
            {
                if (word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break; //when word ends, break the foreach
                }
                
            }
        }
        if (hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
        }
    }
}
