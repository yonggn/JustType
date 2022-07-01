using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingKnowledge : MonoBehaviour
{
    public List<string> knowlegde;
    private int randomInt;
    public TextMeshProUGUI knowledgeText;

    // Start is called before the first frame update
    void Start()
    {
        randomInt = Random.Range(0, knowlegde.Count);
        knowledgeText.text = "- " + knowlegde[randomInt] + " -";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
