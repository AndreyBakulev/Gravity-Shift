using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        // Load saved values, default to 1 if not set
        float master = PlayerPrefs.GetFloat("MasterVolume", 1f);
        float music = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float sfx = PlayerPrefs.GetFloat("SFXVolume", 1f);

        // Set slider values
        masterSlider.value = master;
        musicSlider.value = music;
        sfxSlider.value = sfx;

        // Apply to mixer
        SetMasterVolume(master);
        SetMusicVolume(music);
        SetSFXVolume(sfx);
    }

    public void SetMasterVolume(float value)
    {
    audioMixer.SetFloat("MasterVolume", Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20);
    PlayerPrefs.SetFloat("MasterVolume", value);
    PlayerPrefs.Save();
    }  

    public void SetMusicVolume(float value)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20);
        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float value)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20);
        PlayerPrefs.SetFloat("SFXVolume", value);
        PlayerPrefs.Save();
    }
}