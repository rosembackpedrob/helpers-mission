using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundManager : MonoBehaviour
{
    #region Vars
    public GameObject sound;
    #endregion

    #region Audio Clips and Sources
    [Header("Audio Sources")]
    public AudioSource sfxFont;
    public AudioSource songsFont;

    [Header("AudioClips PauseMenu")]
    public AudioClip pointEnter;
    public AudioClip menuSelect;
    public AudioClip menuSelect2;
    
    [Header("SFXs")]
    public AudioClip jumpSFX;
    public AudioClip fallSFX;
    public AudioClip turnSFX;
    public AudioClip grabSFX;
    public AudioClip pigOink;

    [Header("Songs")]
    public AudioClip song1;
    public AudioClip song2;
    public AudioClip song3;
    public AudioClip finalSong;
    #endregion
    #region "Singleton"
    public static SoundManager Instance = null;

    private void Awake()
    {
        if(Instance == null){
            Instance = this;
        } else if (Instance != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion


    #region Playing Methods
    //Method to Play Point Enter
    public void PlayPointEnter(){
        sfxFont.clip = pointEnter;
        sfxFont.Play();
    }

    //Method to Play Select
    public void PlaySelect(){
        sfxFont.clip = menuSelect;
        sfxFont.Play();

    }

    public void PlaySelect2(){
        sfxFont.clip = menuSelect2;
        sfxFont.Play();
    }
    
    //Method to Play the Soundtrack
    public void PlaySong(AudioClip songClip){
        songsFont.clip = songClip;
        songsFont.Play();
        if(PauseMenu.GameIsPaused)
        {
        soundDown();
        }
    }
    //Creating a Method to Play the SFX
    public void PlaySFX(AudioClip sfxClip){
        sfxFont.clip = sfxClip;
        sfxFont.Play();
    }
    #endregion
    
    
    //Sample Sound When Paused
    public void soundDown()
    {
        songsFont.pitch *= .5f;
    }

    private void Start()
    {
        PlaySong(song1);
    }
}
