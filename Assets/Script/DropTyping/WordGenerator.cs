using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


//Read word from txt file
public class WordGenerator : MonoBehaviour
{
    private static string[] wordlist = { };
    public string myFilePath;
    public string fileName; //= "words.txt";
    public static bool waveStop = false;

    public void ReadFromFile(string filePath)
    {
        wordlist = File.ReadAllLines(filePath);
    }

    public static string GetRandomWord()
    {
        //Get a word from the dictionary here
        int randomIndex = Random.Range(0, wordlist.Length);
        string randomWord = wordlist[randomIndex];
        return randomWord;
    }
}
