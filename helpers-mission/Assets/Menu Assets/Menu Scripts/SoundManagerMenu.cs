using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundManagerMenu : MonoBehaviour
{
    public static SoundManagerMenu Instance = null;
    
    public GameObject sound;
    [Header("Audio Sources")]
    public AudioSource sfxFont;
    public AudioSource songsFont;

    [Header("AudioClips")]
    public AudioClip pointEnter;
    public AudioClip menuSelect;
    public AudioClip menuSelect2;
    public AudioClip menuSong;

    #region "Singleton"
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
    
    //Method to Play the Songs
    public void PlaySong(){
        songsFont.clip = menuSong;
        songsFont.Play();
    }

    
    //play menu song
    void Start()
    {
        PlaySong();
    }
    
    #endregion

    #region Destroying Manager and Fading out
    public void AudioTransition()
    {
        StartCoroutine(Destroy(3f));
        
        //Calling Fade out Coroutine
        StartCoroutine(FadeOut(songsFont, 1f));

    }
    
    IEnumerator Destroy(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
    
    //Fade Out
     public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime) {
        float startVolume = audioSource.volume;
 
        while (audioSource.volume > 0) {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
 
            yield return null;
        }

        audioSource.Stop ();
        audioSource.volume = startVolume;
    }
    #endregion
}
