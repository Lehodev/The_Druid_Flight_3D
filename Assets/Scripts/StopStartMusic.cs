using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopStartMusic : MonoBehaviour
{

    [SerializeField] AudioSource music;
    bool musicPlaying;

    public void Music()
    {
        if (musicPlaying)
        {
            music.Stop();
            musicPlaying = false;
            DontDestroyOnLoad(music);
        }
        else
        {
            music.Play();
            musicPlaying = true;
            DontDestroyOnLoad(music);
        }
    }
}
