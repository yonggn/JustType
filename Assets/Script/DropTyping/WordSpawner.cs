using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    public GameObject wordPrefab;
    public Transform wordCanvas;

    public WordToDisplay SpawnWord()
    { 
            Vector3 randomPosition = new Vector3(Random.Range(-2.0f, 2.0f), 5f);
            //Instantiate prefab
            GameObject wordObject = Instantiate(wordPrefab, randomPosition, Quaternion.identity, wordCanvas);
            WordToDisplay wordDisplay = wordObject.GetComponent<WordToDisplay>();
            //startTimer = true;
            return wordDisplay;
    }
}
