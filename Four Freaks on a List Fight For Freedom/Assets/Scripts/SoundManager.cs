using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioSource[] sounds;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Play(int bob, float time)
    {
        StartCoroutine(PlaySound(bob, time));
    }
    IEnumerator PlaySound(int s, float seconds)
    {
        sounds[s].enabled = true;
        yield return new WaitForSeconds(seconds);
        sounds[s].enabled = false;
    }
}
