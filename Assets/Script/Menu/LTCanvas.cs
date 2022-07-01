using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LTCanvas : MonoBehaviour
{
    public List<GameObject> objectTweenAtStart;
    public float timeForLTAtStart;

    private void Start()
    {
        for(int i =0;i<objectTweenAtStart.Count;i++)
        {
            LTobject(objectTweenAtStart[i], timeForLTAtStart);
        }
    }

    public void LTobject(GameObject objectToLT, float timeForLT)
    {
        LeanTween.cancel(gameObject);
        transform.localScale = Vector3.one;
        LeanTween.scale(objectToLT, Vector3.one*2, timeForLT).setEasePunch();
    }

}
