using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeShine : MonoBehaviour
{
    //This time it is going to react to the spectrum frequency
    private float[] audioSpectrum = new float[128];
    public static float spectrumValue { get; private set; }

    //To set the frequency to react
    public float bias;
    public float timeStep;
    public float timeToBeat;
    public float restSmoothTime;
    private float previousAudioValue;
    private float audioValue;
    private float timer;

    protected bool isBeat;

    // Start is called before the first frame update
    void Start()
    {
        audioSpectrum = new float[128];
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.GetSpectrumData(audioSpectrum, 0, FFTWindow.Hamming);
        if(audioSpectrum!=null && audioSpectrum.Length>0)
        {
            spectrumValue = audioSpectrum[0] * 100;
        }
        OnUpdate();
    }

    public virtual void OnUpdate()
    {
        previousAudioValue = audioValue;
        audioValue = spectrumValue;

        //if value below bias
        if(previousAudioValue>bias && audioValue<=bias)
        {
            if(timer>timeStep)
            { 
                OnBeat();
            }
        }

        //if value above bias
        if(previousAudioValue<=bias && audioValue>bias)
        {
            if(timer>timeStep)
            {
                OnBeat();
            }
        }
        timer += Time.deltaTime;
    }

    public virtual void OnBeat()
    {
        timer = 0;
        isBeat = true;
    }
}
