using System;
using UnityEngine;

public class SoundService : MonoBehaviour
{
    [SerializeField] private AudioSource soundEffect;
    [SerializeField] private AudioSource soundMusic;
    [SerializeField] private AudioSource footStep;
    [SerializeField] private bool IsMute = false;
    [SerializeField] private SoundType[] audioClips;

   
    private void SetMusicStatus()
    {
        if (IsMute)
        {
            soundMusic.volume = 0f;
            return;
        }
        else 
        {           
            soundMusic.volume = 0.5f;
        }      
    }
    public void PlaySound(Sounds sound)
    {
        if (IsMute) return;
        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("Audio Not Assigned");
        }
    }
    private AudioClip GetSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(audioClips, i => i.soundtype == sound);
        if (item != null)
        {
            return item.soundclip;
        }
        else
        {
            return null;
        }
    }
    public void ToggleMute()
    {
        IsMute = !IsMute;       
        if (IsMute) { GameService.Instance.GetPopUpService().ShowPopupMessage("Muted"); }
        else { GameService.Instance.GetPopUpService().ShowPopupMessage("Un-Muted"); }
        SetMusicStatus();
    }
    public void PlayFootStep()
    {
        footStep.enabled = true;
    }
    public void StopFootStep()
    {
        footStep.enabled = false;
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
