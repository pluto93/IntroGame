using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettingsManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider; // Reference to music volume slider
    public Slider sfxSlider;   // Reference to SFX volume slider


    public void SetMusicVolume(float volume)
    {
        Debug.Log("Setting music volume to: " + volume);
        audioMixer.SetFloat("musicVolume", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        Debug.Log("Setting SFX volume to: " + volume);
        audioMixer.SetFloat("sfxVolume", Mathf.Log10(volume) * 20);
    }

    void Start()
    {
        // Load saved volume settings or default to 1
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1);
    }

    public void SaveVolumes()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
        PlayerPrefs.Save();
    }

}
