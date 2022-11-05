using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using AnotherFileBrowser.Windows;

public class ImportMusicFromExplorer : MonoBehaviour
{
    string path;
    public AudioClip auclip;
    public AudioSource source;
    public GameObject startPanel;
    public static bool gameStart = false;
    public GameObject okButton;

    public MusicManager musicManager;

    private void Start()
    {
        okButton.SetActive(false);
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
                musicManager.AnalyseMusic(clipSelected);
                source.clip = clipSelected;
                source.Play();          
            }
        }
        okButton.SetActive(true);
    }

    public void CloseStartPanel()
    {
        startPanel.SetActive(false);
        gameStart = true;
        source.Play();
    }
}
