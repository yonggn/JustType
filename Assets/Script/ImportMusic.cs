using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using AnotherFileBrowser.Windows;
using TMPro;

public class ImportMusic : MonoBehaviour
{
    string path;
    public AudioSource source;
    public float bpm;
    public MusicManager musicManager;
    public LetterOnBeat letterOnBeat;
    public PauseMenu pauseMenu;
    public Grade grade;
    public TextMeshProUGUI bpmText;

    private void Start()
    {
        grade.enabled = false;
        letterOnBeat.enabled = false;
       // auclip = source.clip;
        //AnalyseMusic(auclip);
    }

    public void OpenFileExplorer()
    {
        var bp = new BrowserProperties();
        bp.filter = "Audio files (*.mp3)| *.mp3";
        bp.filterIndex = 0;

        new FileBrowser().OpenFileBrowser(bp,
            path =>
            {
                StartCoroutine(GetMusic(path));
            }
            );
        // path = EditorUtility.OpenFilePanel("Import music", "", "mp3,ogg");
        //StartCoroutine(GetMusic());
        Debug.Log(path);
    }


    IEnumerator GetMusic(string path)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.MPEG))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(www.error);
            }
            else
            {
                AudioClip clipSelected = DownloadHandlerAudioClip.GetContent(www);
                //levelSelection.audioSource.clip = clipSelected;
                //levelSelection.level[9].audioClip = clipSelected;
                source.clip = clipSelected;
                AnalyseMusic(clipSelected);
            }
        }

    }

    public void AnalyseMusic(AudioClip myMusic)
    {
        bpm = UniBpmAnalyzer.AnalyzeBpm(myMusic);
        if (bpm >= 120)
        {
            bpm /= 3;
        }
        if (bpm <= 10)
        {
            bpm *= 3;
        }
        //timeToGenerateNote = 60 / bpm;
        bpmText.text = "BPM : " + bpm;
        musicManager.bpm = bpm;
        source.Play();
        letterOnBeat.GetBPM(bpm);

        pauseMenu.Resume();
        //Invoke("InsertNote", timeToGenerateNote);
    }

    public void StartGame()
    {
        musicManager.source = source;
        musicManager.source.Play();
        grade.enabled = true;
        letterOnBeat.enabled = true;
    }
}
