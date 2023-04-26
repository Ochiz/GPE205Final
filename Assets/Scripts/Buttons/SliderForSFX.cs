using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderForSFX : MonoBehaviour
{
    //variables
    public AudioMixer SFXAudioMixer;
    public Slider SFXVolumeSlider;

    public void Start()
    {
        OnSFXVolumeChange();
    }
    //on slider value change
    public void OnSFXVolumeChange()
    {
        float newVolume = SFXVolumeSlider.value;
        if (newVolume <= 0)
        {
            newVolume = -80;
        }
        else
        {
            newVolume = Mathf.Log10(newVolume);
            newVolume = newVolume * 20;
        }
        SFXAudioMixer.SetFloat("sfxVolume", newVolume);
    }
    //how SFX volume works
    //first we get the value from the SFX slider 
    //then we change the variable to a value that
    //the audio mixer can use by taking the Log10 of
    //it and then multiplying by 20 then we set the music
    //volume portion of our mixer to the value
}
