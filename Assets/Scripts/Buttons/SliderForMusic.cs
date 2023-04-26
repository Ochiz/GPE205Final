using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderForMusic : MonoBehaviour
{
    //variables
    public AudioMixer musicAudioMixer;
    public Slider musicVolumeSlider;

    public void Start()
    {
        OnMusicVolumeChange();
    }
    //on slider value change
    public void OnMusicVolumeChange()
    {
        float newVolume = musicVolumeSlider.value;
        if (newVolume <= 0)
        {
            newVolume = -80;
        }
        else
        {
            newVolume = Mathf.Log10(newVolume);
            newVolume = newVolume * 20;
        }
        musicAudioMixer.SetFloat("musicVolume", newVolume);
    }
    //how music volume works
    //first we get the value from the music slider 
    //then we change the variable to a value that
    //the audio mixer can use by taking the Log10 of
    //it and then multiplying by 20 then we set the music
    //volume portion of our mixer to the value
}
