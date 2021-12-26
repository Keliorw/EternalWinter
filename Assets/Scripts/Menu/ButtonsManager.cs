using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    private SoundManager soundManager;
    private MusicManager musicManager;
     private Save save;
    public GameObject MenuPanel;
    public GameObject CollectionPanel;
    public GameObject GiftPanel;
    public GameObject SettingsPanel;
    public GameObject CloseSettingsPanel;
    
    void Start()
    {   
        soundManager = SoundManager.instance;
        musicManager = MusicManager.instance;
        save = Save.instance;
        MenuPanel.SetActive(true);
        CollectionPanel.SetActive(false);
        GiftPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        CloseSettingsPanel.SetActive(false);
    }

    public void ActiveMenuPanel () {
        soundManager.PlaySound();
        MenuPanel.SetActive(true);
        CollectionPanel.SetActive(false);
        GiftPanel.SetActive(false);
        SettingsPanel.SetActive(false);
    }

    public void ActiveCollectionPanel () {
        soundManager.PlaySound();
        CollectionPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }

    public void ActiveGiftPanel () {
        soundManager.PlaySound();
        GiftPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }
    public void ActiveSettingsPanel () {
        soundManager.PlaySound();
        if (SettingsPanel.activeSelf == true) {
            save.SaveSound(soundManager.soundVolume);
            save.SaveMusic(musicManager.musicVolume);
            SettingsPanel.SetActive(false);
            CloseSettingsPanel.SetActive(false);
        } else {
            SettingsPanel.SetActive(true);
            CloseSettingsPanel.SetActive(true);
        }
    }

    public void Play (int id) {
        soundManager.PlaySound();
        SceneManager.LoadScene(id);
    }
}
