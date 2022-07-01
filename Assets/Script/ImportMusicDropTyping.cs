using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using AnotherFileBrowser.Windows;

public class ImportMusicDropTyping : MonoBehaviour
{
    string path;
    public AudioClip auclip;
    public AudioSource source;
    public GameObject startPanel;
    public static bool gameStart = false;

    private void Start()
    {
        gameStart = false;
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
                source.Play();
                //AnalyseMusic(clipSelected);
            }
        }

    }

    public void CloseStartPanel()
    {
        startPanel.SetActive(false);
        gameStart = true;
        source.Play();
    }

    /*public void AnalyseMusic(AudioClip myMusic)
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
        source.Play();
        //Invoke("InsertNote", timeToGenerateNote);
    }*/
}
