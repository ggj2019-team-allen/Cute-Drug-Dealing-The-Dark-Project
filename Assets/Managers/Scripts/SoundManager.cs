using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Variables
    //Static instance of GameManager which allows it to be accessed by any other script.
    public static SoundManager instance = null;

    [Header("Audio Tracks")]
    public SFXAudioTrack[] sfxTracks;
    public BGMAudioTrack[] bgmTracks;

    [Header("Audio Sources")]
    public AudioSource sfxSourceOneShot;
    public List<AudioSource> sfxSourcesLooping;
    public AudioSource bgmSource;

    [Header("Settings")]
    [ContextMenuItem("Update", "UpdateSFXVolume")]
    public float sfxVolume = 1.0f;
    [ContextMenuItem("Update", "UpdateBGMVolume")]
    public float bgmVolume = 0.5f;

    // Delegates
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);    
        }
        
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Instantiate the audio sources if they are not yet created
        if(sfxSourceOneShot == null)
        {
            sfxSourceOneShot = gameObject.AddComponent<AudioSource>();
        }

        if(bgmSource == null)
        {
            bgmSource = gameObject.AddComponent<AudioSource>();
        }
    }
    
    void OnValidate()
    {
        //Update array's size to match the number of tracks in equal
        if (sfxTracks.Length != (int)SFXAudioID.TOTAL)
        {
            Array.Resize(ref sfxTracks, (int)SFXAudioID.TOTAL);
        }

        if (bgmTracks.Length != (int)BGMAudioID.TOTAL)
        {
            Array.Resize(ref bgmTracks, (int)BGMAudioID.TOTAL);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private AudioClip SearchAudioClip(SFXAudioID id)
    {
        for(int i = 0; i < sfxTracks.Length; ++i)
        {
            if(sfxTracks[i].id == id)
            {
                return sfxTracks[i].clip;
            }
        }
        return null;
    }

    private AudioClip SearchAudioClip(BGMAudioID id)
    {
        for(int i = 0; i < bgmTracks.Length; ++i)
        {
            if(bgmTracks[i].id == id)
            {
                return bgmTracks[i].clip;
            }
        }
        return null;
    }

    public void PlaySFXOneShot(SFXAudioID id)
    {
        sfxSourceOneShot.PlayOneShot(SearchAudioClip(id));
    }

    public void PlaySFXLooping(SFXAudioID id)
    {
        AudioSource newSource = gameObject.AddComponent<AudioSource>();
        sfxSourcesLooping.Add(newSource);
        newSource.volume = sfxVolume;
        newSource.loop = true;
        newSource.clip = SearchAudioClip(id);
        newSource.Play();
    }

    public void PlayBGM(BGMAudioID id)
    {
        StopBGM();
        bgmSource.loop = true;
        bgmSource.clip = SearchAudioClip(id);
        bgmSource.Play();
    }

    public bool StopSFX(SFXAudioID id)
    {
        for(int i = 0; i < sfxSourcesLooping.Count; ++i)
        {
            if(sfxSourcesLooping[i].clip = SearchAudioClip(id))
            {
                sfxSourcesLooping[i].Stop();
                Destroy(sfxSourcesLooping[i]);
                sfxSourcesLooping.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        UpdateSFXVolume();
    }

    public void UpdateSFXVolume()
    {
        sfxSourceOneShot.volume = sfxVolume;
        for(int i = 0; i < sfxSourcesLooping.Count; ++i)
        {
            sfxSourcesLooping[i].volume = sfxVolume;
        }
    }

    public void SetBGMVolume(float volume)
    {
        bgmVolume = volume;
        UpdateBGMVolume();
    }

    public void UpdateBGMVolume()
    {
        bgmSource.volume = bgmVolume;
    }
}
