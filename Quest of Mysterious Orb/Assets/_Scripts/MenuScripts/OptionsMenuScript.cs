using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class OptionsMenuScript : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Rect SliderLocation;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetBrightnesss(float brightness)
    {
        RenderSettings.ambientLight = new Color(brightness, brightness, brightness, 1.0f);
    }






}

