using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class MusicManagerGame : MonoBehaviour
{
    private AudioSource musicSrc;
    public float musicVolume;
    private Save save;
    void Start()
    {
        save = Save.instance;
        musicSrc = GetComponent<AudioSource>();
        musicVolume = save.GetMusic();
        musicSrc.volume = musicVolume;
    }
}
