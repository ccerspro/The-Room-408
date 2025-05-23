using System.Collections;
using UnityEngine.Audio;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ZhouSoftware{
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
     foreach (Sound s in sounds) {
        s.source = gameObject.AddComponent<AudioSource>();
        s.source.clip = s.clip;
        s.source.volume = s.volume;
        s.source.pitch = s.pitch;
     }  
    }

    // Update is called once per frame
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.Play();
    }

    public bool IsPlaying(string name)
    {
    Sound s = Array.Find(sounds, sound => sound.name == name);
    if (s == null)
    {
        Debug.LogWarning($"Sound {name} not found!");
        return false;
    }
    return s.source.isPlaying;
    }

    public void Stop(string name)
    {
    Sound s = Array.Find(sounds, sound => sound.name == name);
    if (s == null)
    {
        Debug.LogWarning($"Sound {name} not found!");
        return;
    }
    s.source.Stop();
    }
}
}
