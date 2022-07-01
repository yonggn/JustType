using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class ReadGoogleSheet : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI wordText;
    string updateText = "";

    string jsonURL = "https://opensheet.elk.sh/1QftuAm3vkojX8izIGPExRj5mFGhEg_nEYVG8fQvuDIE/1";

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        StartCoroutine(ObtainSheetData(jsonURL));
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        StartCoroutine(ObtainSheetData(jsonURL));
    }

    [System.Obsolete]
    IEnumerator ObtainSheetData(string url)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError||www.isHttpError)
        {
            Debug.Log("ERROR: ");
        }
        else
        {
            string json = www.downloadHandler.text;
            var o = JSON.Parse(json);
            foreach (var word in o)
            {
                var item = JSON.Parse(word.ToString());
                updateText += item[0]["Word"]+",";
                
            }
            wordText.text = updateText;
            Debug.Log("importing json word");
        }
    }
}
