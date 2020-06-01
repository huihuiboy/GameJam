using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class bgmanager : MonoBehaviour
{
    public sound[] sounds;
    AudioSource ads;

    private void Awake()
    {
        foreach(sound x in sounds)
        {
            x.souurce = gameObject.AddComponent<AudioSource>();
            x.souurce.clip = x.clip;
            x.souurce.volume = x.volume;
            x.souurce.loop = x.loop;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ads = GetComponent<AudioSource>();
    }

    public void Play (string name)
    {
        sound x = Array.Find(sounds, sound => sound.name == name);
        x.souurce.Play();
    }
}
