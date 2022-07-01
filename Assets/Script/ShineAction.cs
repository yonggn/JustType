using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ShineAction : EdgeShine
{
    //The alpha cannot change by itself, it has to be controlled by the color
    public Color beatColors;
    public Color restColor;

    private int randomIndex;
    private Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    public override void OnUpdate()
    {
        base.OnUpdate();
        if (isBeat) return;
        img.color = Color.Lerp(img.color, restColor, restSmoothTime * Time.deltaTime);
    }

    public override void OnBeat()
    {
        base.OnBeat();
        StopCoroutine("MoveToColor");
        StartCoroutine("MoveToColor",beatColors);
    }

    private IEnumerator MoveToColor(Color target)
    {
        Color curr = img.color;
        Color init = curr;

        float timer = 0;
        while (curr !=target)
        {
            curr = Color.Lerp(init, target, timer / timeToBeat);
            timer += Time.deltaTime;
            img.color = curr;
            yield return null;
        }
        isBeat = false;
    }
}
