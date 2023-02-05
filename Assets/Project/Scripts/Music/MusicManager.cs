using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    private AudioSource _audio;
    [SerializeField] private AudioClip _calmMusic;
    [SerializeField] private AudioClip _fightMusic;

    private void Awake()
    {
        if(instance == null)
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
        _audio = GetComponent<AudioSource>();
        PlayCalmMusic();
    }

    public void PlayCalmMusic()
    {
        _audio.clip = _calmMusic;
        _audio.Play();
    }

    public void PlayFightMusic()
    {
        _audio.clip = _fightMusic;
        _audio.Play();
    }
}
