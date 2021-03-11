using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer am;
    bool isFullScreen;
    Resolution[] rsl;
    List<string> resolutions;
    public Dropdown dropdown;

    private void Awake()
    {
        resolutions = new List<string>();
        rsl = Screen.resolutions;
        foreach (var i in rsl)
        {
            if (i.width > 1000)
            {
                resolutions.Add(i.width + "x" + i.height);
            }
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(resolutions);
    }
    
    public void Resolution(int r)
    {
        Screen.SetResolution(rsl[r].width, rsl[r].height, isFullScreen);
    }

    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }
    public void AudioVolume (float sliderValue)
    {
        am.SetFloat("masterVolume", sliderValue);
    }
    public void Quality (int q)
    {
        QualitySettings.SetQualityLevel(q);
    }

}
