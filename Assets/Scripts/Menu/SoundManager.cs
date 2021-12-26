using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class SoundManager : MonoBehaviour
{
    private AudioSource soundSrc;
    [SerializeField] Button SoundButton = null;
    public Sprite SoundOn;
    public Sprite SoundOff;
    public float soundVolume;
    public Slider SoundSlider;

    private Save save;
    public static SoundManager instance;

    private void Awake() {
        instance = this;
    }
    private void Start() 
    {
        save = Save.instance;
        soundSrc = GetComponent<AudioSource>();
        soundVolume = save.GetSound();
        SoundSlider.value = soundVolume;
    }
    
    void Update()
    {
        soundSrc.volume = soundVolume;
        if (soundVolume <= 0f) {
            SoundButton.image.sprite = SoundOff;
        } else {
            SoundButton.image.sprite = SoundOn;
        }
    }

    public void SetSoundVolume() {
        PlaySound();
        if (soundVolume > 0f) {
            soundVolume = 0f;
            SoundSlider.value = soundVolume;
            save.SaveSound(soundVolume);
        } else {
            soundVolume = 1f;
            SoundSlider.value = soundVolume;
            save.SaveSound(soundVolume);
        }
    }
    public void PlaySound () {
        soundSrc.Play();
    }

    public void SetCountScrollbar(float vol) {
        soundVolume = vol;
        save.SaveSound(soundVolume);
    }
    
}
