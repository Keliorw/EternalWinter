using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class MusicManager : MonoBehaviour
{    
    private SoundManager soundManager;
    private AudioSource musicSrc;
    [SerializeField] Button MusicButton = null;
    public Sprite MusicOn;
    public Sprite MusicOff;
    public float musicVolume;
    public Slider MusicSlider;

    public static MusicManager instance;

    private Save save;

    private void Awake() {
        instance = this;
    }

    void Start()
    {
        save = Save.instance;
        soundManager = SoundManager.instance;
        musicSrc = GetComponent<AudioSource>();
        musicVolume = save.GetMusic();
        MusicSlider.value = musicVolume;
    }

    void Update()
    {
        musicSrc.volume = musicVolume;
        if (musicVolume <= 0f) {
            MusicButton.image.sprite = MusicOff;
        } else {
            MusicButton.image.sprite = MusicOn;
        }
    }

    public void SetMusicVolume() {
        soundManager.PlaySound();
        if (musicVolume > 0f) {
            musicVolume = 0f;
            MusicSlider.value = musicVolume;
            save.SaveMusic(musicVolume);
        } else {
            musicVolume = 1f;
            MusicSlider.value = musicVolume;
            save.SaveMusic(musicVolume);
        }
    }

    public void SetCountScrollbar(float vol) {
        musicVolume = vol;
        save.SaveMusic(musicVolume);
      }
}
