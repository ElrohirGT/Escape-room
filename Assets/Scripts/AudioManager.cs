using System;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public enum Sound
    {
        PickUpCoin,
        Death,
    }

    [SerializeField] private AudioClip pickUpCoin;
    [SerializeField] private AudioClip death;

    public static AudioManager Instance { get; private set; }

    private AudioSource _effectsSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Instance != null)
        {
            Destroy(this);
        }

        Instance = this;
        _effectsSource = GetComponent<AudioSource>();

        PauseManager.OnPause += (sender, args) =>
        {
            _effectsSource.pitch = 0;
        };

        PauseManager.OnResume += (sender, args) =>
        {
            _effectsSource.pitch = 1;
        };
    }

    private AudioClip ToClip(Sound s)
    {
        return s switch
        {
            Sound.PickUpCoin => pickUpCoin,
            Sound.Death => death,
            _ => null
        };
    }

    public void PlayEffect(Sound s)
    {
        AudioClip clip = ToClip(s);
        _effectsSource.PlayOneShot(clip);
    }
}