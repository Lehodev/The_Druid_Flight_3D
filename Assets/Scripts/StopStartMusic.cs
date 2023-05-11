using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopStartMusic : MonoBehaviour
{

    [SerializeField] public AudioSource music;
    public static StopStartMusic controller;
    bool musicPlaying;
    public GameObject holder;


    public void Start()
    {
        DontDestroyOnLoad(holder);
    }

    public void Music()
    {
        if (musicPlaying)
        {
            music.Stop();
            musicPlaying = false;
        }
        else
        {
            music.Play();
            musicPlaying = true;
        }
    }

    public void DestroyOnRetry()
    {
        Destroy(holder);
    }
}
