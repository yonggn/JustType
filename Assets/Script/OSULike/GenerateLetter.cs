using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateLetter : MonoBehaviour
{
    public GameObject letterPrefab;
    private GameObject letterObject;
    public Transform canvas;
    public TextMeshProUGUI letterText;
    private List<string> letter = new List<string> {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
    private int randomLetterIndex;
    public string letterShown;
    private float posX;
    private float posY;
    public AudioSource correctSound;

    public ParticleSystem particleObject;

    public bool canPress = true;

    public LetterOnBeat letterOnBeat;
    public Grade grade;

    public Score score;

    public Vector3 pos;


    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (canPress)
            {
                foreach (char letter in Input.inputString)
                {
                    canPress = true;
                    if (Input.inputString == letterShown.ToString()) //If player press correct
                    {
                        correctSound.Play();
                        particleObject.transform.position = pos;
                        particleObject.Play();
                        letterObject.gameObject.SetActive(false);

                        //Determine grade using time to react
                        if (letterOnBeat.spawnTimer >= 0 && letterOnBeat.spawnTimer <= (letterOnBeat.timeToGenerateNote + letterOnBeat.alignTime) / 2) //and hit on time
                        {                            
                            grade.perfect = true;
                            score.score += 2;
                            canPress = false;
                        }
                        if (letterOnBeat.spawnTimer >= (letterOnBeat.timeToGenerateNote + letterOnBeat.alignTime) / 2 && letterOnBeat.spawnTimer <= (letterOnBeat.timeToGenerateNote + letterOnBeat.alignTime)) //and hit
                        {
                            grade.good = true;
                            score.score++;
                            canPress = false;
                        }
                    }
                    else if (Input.inputString != letterShown.ToString()) //if player press wrong 
                    {
                        letterObject.gameObject.SetActive(false);
                        grade.miss = true;
                        score.score--;
                        canPress = false;
                    }


                }

            }
            if (letterOnBeat.spawnTimer >= (letterOnBeat.timeToGenerateNote + letterOnBeat.alignTime) - 0.01 && canPress)
            {
                letterObject.gameObject.SetActive(false);
                grade.miss = true;
                canPress = false;
                score.score--;
            }
        }

    }

    public void RandomizeLetter()
    {
        randomLetterIndex = Random.Range(0, letter.Count);
        letterShown = letter[randomLetterIndex];
        letterText.text = letterShown.ToString();
        RandomPosition();
    }

    public void RandomPosition()
    { 
        Vector2 bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        float minX = -bounds.x+3;
        float maxX = bounds.x-3;
        float minY = -bounds.y+3;
        float maxY = bounds.y-3;

        posX = Random.Range(minX,maxX);
        posY = Random.Range(minY,maxY);
        pos = new Vector3(posX, posY,3.0f);

        canPress = true;
        Destroy(letterObject);
        letterObject = Instantiate(letterPrefab, pos, Quaternion.identity, canvas);
    }

}
