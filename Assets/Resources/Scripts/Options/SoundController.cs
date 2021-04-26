using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController
{
    public float MusicVolume => _musicVolume;
    public float SoundVolume => _soundVolume;

    private float _musicVolume;
    private float _soundVolume;

    private float _multiplyer = 20f;

    private AudioSource _musicSource;
    private AudioSource _soundsSource;

    private string _musicVolumeKey = "MUSIC_VOLUME";
    private string _soundVolumeKey = "SOUND_VOLUME";

    public SoundController(AudioSource sounds, AudioSource musics)
    {
        _soundsSource = sounds;
        _musicSource = musics;

        LoadSettings();
    }

    public void SetMusicVolume(float volume)
    {
        _musicVolume = volume;
        _musicSource.volume = _musicVolume;
    }

    public void SetSoundVolume(float volume)
    {
        _soundVolume = volume;
        _soundsSource.volume = _soundVolume;
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

        _musicSource.volume = _musicVolume;
        _soundsSource.volume = _soundVolume;
    }

    public void PlayMusic(AudioClip clip, bool loop = false)
    {
        _musicSource.Stop();

        _musicSource.clip = clip;
        _musicSource.loop = loop;

        _musicSource.Play();
    }

    public void PlaySound(AudioClip clip, bool loop = false)
    {
        _soundsSource.Stop();

        _soundsSource.clip = clip;
        _soundsSource.loop = loop;

        _soundsSource.Play();
    }
}
