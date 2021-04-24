using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOptions
{
    public float MusicVolume => _musicVolume;
    public float SoundVolume => _soundVolume;

    private float _musicVolume;
    private float _soundVolume;

    private string _musicVolumeKey = "MUSIC_VOLUME";
    private string _soundVolumeKey = "SOUND_VOLUME";

    public SoundOptions()
    {
        LoadSettings();
    }

    public void SetMusicVolume(float volume)
    {
        _musicVolume = volume;
    }

    public void SetSoundVolume(float volume)
    {
        _soundVolume = volume;
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat(_musicVolumeKey, _musicVolume);
        PlayerPrefs.SetFloat(_soundVolumeKey, _soundVolume);
    }

    private void LoadSettings()
    {
        _musicVolume = PlayerPrefs.GetFloat(_musicVolumeKey, 0.5f);
        _soundVolume = PlayerPrefs.GetFloat(_soundVolumeKey, 0.5f);
    }
}
