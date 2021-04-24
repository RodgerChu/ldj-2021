using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _soundsVolumeSlider;

    [Inject] private SoundOptions _soundOptions;

    private void Start()
    {
        _musicVolumeSlider.value = _soundOptions.MusicVolume;
        _soundsVolumeSlider.value = _soundOptions.SoundVolume;

        _musicVolumeSlider.onValueChanged.AddListener(volume =>
        {
            _soundOptions.SetMusicVolume(volume);
            _soundOptions.SaveSettings();
        });

        _soundsVolumeSlider.onValueChanged.AddListener(volume =>
        {
            _soundOptions.SetSoundVolume(volume);
            _soundOptions.SaveSettings();
        });
    }
}
