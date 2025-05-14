using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Clips")]
    public AudioClip[] audioClips;
    /// <summary>
    /// Clip Indexes =
    /// 0 = Bat transform
    /// 1 = Shotgun
    /// 2 = Disc Bomb
    /// 3 = Fencer Stab
    /// 4 = Fencer Swing
    /// 5 = Portal Hand
    /// 6 = Rockstar Guitar
    /// 7 = Hurt SFX
    /// 8 = Jump SFX
    /// 9 = Smash Sound
    /// 10 = Table Spawn
    /// 11 = Laser FX
    /// 12 = Counter
    /// 13 = Teleport
    /// </summary>

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void Play(int index)
    {
        if (index < 0 || index >= audioClips.Length || audioClips[index] == null)
        {
            Debug.LogWarning("Invalid AudioClip index.");
            return;
        }

        // Create a new AudioSource component
        AudioSource newSource = gameObject.AddComponent<AudioSource>();
        newSource.clip = audioClips[index];
        newSource.volume = 0.2f;
        newSource.Play();

        // Destroy the AudioSource after it finishes playing
        Destroy(newSource, audioClips[index].length);
    }
}
