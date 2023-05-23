using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = s.obj.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.onAwake;
        }
    }

    public void Play (string name)
    {
        Debug.Log(name);
        Sound s =Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
