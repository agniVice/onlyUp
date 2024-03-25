using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public bool IsMusicEnabled { get; private set; }
    public bool IsAudioEnabled { get; private set; }

    [SerializeField] private GameObject _audioImage;
    [SerializeField] private GameObject _musicImage;

    [SerializeField] private List<AudioSource> _audioSources;
    [SerializeField] private AudioSource _musicSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;

        IsMusicEnabled = Convert.ToBoolean(PlayerPrefs.GetInt("IsMusicEnabled", 1));
        IsAudioEnabled = Convert.ToBoolean(PlayerPrefs.GetInt("IsAudioEnabled", 1));

        CheckAudioAndMusic();
    }

    private void CheckAudioAndMusic()
    {
        foreach (AudioSource audio in _audioSources)
            audio.mute = !IsAudioEnabled;

        _musicSource.mute = !IsMusicEnabled;

        _musicImage.SetActive(!IsMusicEnabled);
        _audioImage.SetActive(!IsAudioEnabled);
    }
    public void ToggleMusic()
    {
        IsMusicEnabled = !IsMusicEnabled;
        PlayerPrefs.SetInt("IsMusicEnabled", Convert.ToInt32(IsMusicEnabled));
        _musicImage.SetActive(!IsMusicEnabled);

        CheckAudioAndMusic();
    }
    public void ToggleAudio()
    {
        IsAudioEnabled = !IsAudioEnabled;
        PlayerPrefs.SetInt("IsAudioEnabled", Convert.ToInt32(IsAudioEnabled));
        _audioImage.SetActive(!IsAudioEnabled);

        CheckAudioAndMusic();
    }
}