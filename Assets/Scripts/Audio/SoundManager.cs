using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }
    public AudioSource footstepsSound;
    public AudioSource SoundEffect;
    public AudioSource SoundMusic;   
    public SoundType[] Sounds;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        PlayMusic(global::Sounds.BGMusic);
    }
    public void PlayMusic(Sounds sound)
    {      
        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            SoundMusic.clip = clip;
            SoundMusic.Play();
        }
        else
        {
            Debug.Log("Audio Not Assigned");
        }
    }

    public void PlayFootStep(float horispeed)
    {       
            if (horispeed != 0)
            {
                footstepsSound.enabled = true;
            }
            else
            {
                footstepsSound.enabled = false;
            }       
    }
    public void StopFootSound()
    {
        footstepsSound.enabled = false;
    }
    public void PlaySound(Sounds sound)
    {      
        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            SoundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("Audio Not Assigned");
        }
    }
    private AudioClip GetSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(Sounds, i => i.soundtype == sound);
        if (item != null)
        {
            return item.soundclip;
        }
        else
        {
            return null;
        }
    }
}
[Serializable]
public class SoundType
{
    public Sounds soundtype;
    public AudioClip soundclip;
}

public enum Sounds
{
    BGMusic,
    ButtonClick,
    AttackSound,
    DeathSound,
    JumpSound,
    SlideSound,
    HealthLostSound,
    LevelCompleteSound,
    LevelFallLostSound,  
}
