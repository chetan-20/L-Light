using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }   
    [SerializeField] private AudioSource SoundEffect;
    [SerializeField] private AudioSource SoundMusic;
    [SerializeField] private SoundType[] Sounds;
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
        PlayMusic();
    }
    private void PlayMusic()
    {            
        if (SoundMusic != null)
        {          
            SoundMusic.Play();
        }
        else
        {
            Debug.Log("Audio Not Assigned");
        }
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
    ButtonClick,
    AttackSound,
    DeathSound,
    JumpSound,
    SlideSound,
    HealthLostSound,
    LevelCompleteSound,
    LightOffSound
}
