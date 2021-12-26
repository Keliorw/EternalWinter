using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Save : MonoBehaviour
{
    public static Save instance;
    public float StartMoney;
    public int StartGifts;
    public float defaultSound;
    public float defaultMusic;
    public int UnitsCount;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } 
        else 
        {
            throw new System.Exception("Save already declared");
        }
        
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if (pause) {
            PlayerPrefs.Save();
        }
    }
#endif
    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }

    public void SaveMoney(float Money)
    {
        PlayerPrefs.SetFloat("Money", Money);
    }

    public float GetMoney()
    {
        if(PlayerPrefs.HasKey("Money"))
        {
            return PlayerPrefs.GetFloat("Money");
        }
        else 
        {
            PlayerPrefs.SetFloat("Money", StartMoney);
            return PlayerPrefs.GetFloat("Money");
        }
    }

    public void SaveSound(float Volume)
    {
        PlayerPrefs.SetFloat("SoundVolume", Volume);
    }

    public float GetSound()
    {
        if(PlayerPrefs.HasKey("SoundVolume"))
        {
            return PlayerPrefs.GetFloat("SoundVolume");
        }
        else 
        {
            PlayerPrefs.SetFloat("SoundVolume", defaultSound);
            return PlayerPrefs.GetFloat("SoundVolume");
        }
    }

    public void SaveMusic(float Volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", Volume);
    }

    public float GetMusic()
    {
        if(PlayerPrefs.HasKey("MusicVolume"))
        {
            return PlayerPrefs.GetFloat("MusicVolume");
        }
        else 
        {
            PlayerPrefs.SetFloat("MusicVolume", defaultMusic);
            return PlayerPrefs.GetFloat("MusicVolume");
        }
    }

    public void SaveGifts(int Gift)
    {
        PlayerPrefs.SetInt("Gifts", Gift);
    }

    public int GetGifts()
    {
        if(PlayerPrefs.HasKey("Gifts"))
        {
            return PlayerPrefs.GetInt("Gifts");
        }
        else 
        {
            PlayerPrefs.SetInt("Gifts", StartGifts);
            return PlayerPrefs.GetInt("Gifts");
        }
    }

    public void SaveBearUnit(float Level = -1, float Cards = 0, float AttackSpeed = 0.0f, float Health = 0)
    {
        if(Level != -1)
        {
            PlayerPrefs.SetFloat("Bear_Level", Level);
        }
        if(Cards != 0)
        {
            PlayerPrefs.SetFloat("Bear_Cards", Cards);
        }
        if(AttackSpeed != 0.0f)
        {
            PlayerPrefs.SetFloat("Bear_AttackSpeed", AttackSpeed);
        }
        if(Health != 0)
        {
            PlayerPrefs.SetFloat("Bear_Health", Health);
        }
        PlayerPrefs.Save();
    }

    public float GetBearStatsUnit(string key)
    {
        switch(key)
        {
            case "Bear_Level":
                if(PlayerPrefs.HasKey(key))
                {
                    return PlayerPrefs.GetFloat(key);
                }
                else 
                {
                    PlayerPrefs.SetFloat(key, 1);
                    return PlayerPrefs.GetFloat(key);
                }
            case "Bear_Cards":
                if(PlayerPrefs.HasKey(key))
                {
                    return PlayerPrefs.GetFloat(key);
                }
                else 
                {
                    PlayerPrefs.SetFloat(key, 0);
                    return PlayerPrefs.GetFloat(key);
                }
            case "Bear_AttackSpeed":
                if(PlayerPrefs.HasKey(key))
                {
                    return PlayerPrefs.GetFloat(key);
                }
                else 
                {
                    PlayerPrefs.SetFloat(key, 15);
                    return PlayerPrefs.GetFloat(key);
                }
            case "Bear_Health":
                if(PlayerPrefs.HasKey(key))
                {
                    return PlayerPrefs.GetFloat(key);
                }
                else 
                {
                    PlayerPrefs.SetFloat(key, 25);
                    return PlayerPrefs.GetFloat(key);
                }
            default:
                return 0.0f;
        }
    }

    public string GetBearName()
    {
        if(PlayerPrefs.HasKey("Bear_name"))
        {
            return PlayerPrefs.GetString("Bear_name");
        }
        else 
        {
            PlayerPrefs.SetString("Bear_name", "Bear");
            return PlayerPrefs.GetString("Bear_name");
        }
        
    }

    public void SaveElfUnit(float Level = -1, float Cards = 0, float AttackSpeed = 0.0f, float Health = 0, float Damage = 0)
    {
        if(Level != -1)
        {
            PlayerPrefs.SetFloat("Elf_Level", Level);
        }
        if(Cards != 0)
        {
            PlayerPrefs.SetFloat("Elf_Cards", Cards);
        }
        if(AttackSpeed != 0.0f)
        {
            PlayerPrefs.SetFloat("Elf_AttackSpeed", AttackSpeed);
        }
        if(Health != 0)
        {
            PlayerPrefs.SetFloat("Elf_Health", Health);
        }
        if(Damage != 0)
        {
            PlayerPrefs.SetFloat("Elf_Damage", Damage);
        }
        PlayerPrefs.Save();
    }

    public float GetElfStatsUnit(string key)
    {
        switch(key)
        {
            case "Elf_Level":
                if(PlayerPrefs.HasKey(key))
                {
                    return PlayerPrefs.GetFloat(key);
                }
                else 
                {
                    PlayerPrefs.SetFloat(key, 1);
                    return PlayerPrefs.GetFloat(key);
                }
            case "Elf_Cards":
                if(PlayerPrefs.HasKey(key))
                {
                    return PlayerPrefs.GetFloat(key);
                }
                else 
                {
                    PlayerPrefs.SetFloat(key, 0);
                    return PlayerPrefs.GetFloat(key);
                }
            case "Elf_AttackSpeed":
                if(PlayerPrefs.HasKey(key))
                {
                    return PlayerPrefs.GetFloat(key);
                }
                else 
                {
                    PlayerPrefs.SetFloat(key, 6);
                    return PlayerPrefs.GetFloat(key);
                }
            case "Elf_Health":
                if(PlayerPrefs.HasKey(key))
                {
                    return PlayerPrefs.GetFloat(key);
                }
                else 
                {
                    PlayerPrefs.SetFloat(key, 25);
                    return PlayerPrefs.GetFloat(key);
                }
            case "Elf_Damage":
                if(PlayerPrefs.HasKey(key))
                {
                    return PlayerPrefs.GetFloat(key);
                }
                else 
                {
                    PlayerPrefs.SetFloat(key, 80);
                    return PlayerPrefs.GetFloat(key);
                }
            default:
                return 0.0f;
        }
    }

    public string GetElfName()
    {
        if(PlayerPrefs.HasKey("Elf_name"))
        {
            return PlayerPrefs.GetString("Elf_name");
        }
        else 
        {
            PlayerPrefs.SetString("Elf_name", "Elf");
            return PlayerPrefs.GetString("Elf_name");
        }
    }

    public void SavePenguinUnit(float Level = -1, float Cards = 0, float AttackSpeed = 0.0f, float Health = 0, float Damage = 0)
    {
        if(Level != -1)
        {
            PlayerPrefs.SetFloat("Penguin_Level", Level);
        }
        if(Cards != 0)
        {
            PlayerPrefs.SetFloat("Penguin_Cards", Cards);
        }
        if(AttackSpeed != 0.0f)
        {
            PlayerPrefs.SetFloat("Penguin_AttackSpeed", AttackSpeed);
        }
        if(Health != 0)
        {
            PlayerPrefs.SetFloat("Penguin_Health", Health);
        }
        if(Damage != 0)
        {
            PlayerPrefs.SetFloat("Penguin_Damage", Damage);
        }
        PlayerPrefs.Save();
    }

    public float GetPenguinStatsUnit(string key)
    {
        switch(key)
        {
            case "Penguin_Level":
                if(PlayerPrefs.HasKey(key))
                {
                    return PlayerPrefs.GetFloat(key);
                }
                else 
                {
                    PlayerPrefs.SetFloat(key, 1);
                    return PlayerPrefs.GetFloat(key);
                }
            case "Penguin_Cards":
                if(PlayerPrefs.HasKey(key))
                {
                    return PlayerPrefs.GetFloat(key);
                }
                else 
                {
                    PlayerPrefs.SetFloat(key, 0);
                    return PlayerPrefs.GetFloat(key);
                }
            case "Penguin_AttackSpeed":
                if(PlayerPrefs.HasKey(key))
                {
                    return PlayerPrefs.GetFloat(key);
                }
                else 
                {
                    PlayerPrefs.SetFloat(key, 3);
                    return PlayerPrefs.GetFloat(key);
                }
            case "Penguin_Health":
                if(PlayerPrefs.HasKey(key))
                {
                    return PlayerPrefs.GetFloat(key);
                }
                else 
                {
                    PlayerPrefs.SetFloat(key, 25);
                    return PlayerPrefs.GetFloat(key);
                }
            case "Penguin_Damage":
                if(PlayerPrefs.HasKey(key))
                {
                    return PlayerPrefs.GetFloat(key);
                }
                else 
                {
                    PlayerPrefs.SetFloat(key, 25);
                    return PlayerPrefs.GetFloat(key);
                }
            default:
                return 0.0f;
        }
    }

    public string GetPenguinName()
    {
        if(PlayerPrefs.HasKey("Penguin_name"))
        {
            return PlayerPrefs.GetString("Penguin_name");
        }
        else 
        {
            PlayerPrefs.SetString("Penguin_name", "Penguin");
            return PlayerPrefs.GetString("Penguin_name");
        }
    }

    public void SaveCookieUnit(float Level = -1, float Cards = 0, float Health = 0)
    {
        if(Level != -1)
        {
            if(PlayerPrefs.HasKey("Cookie_Level"))
            {
                PlayerPrefs.SetFloat("Cookie_Level", Level);
            }
            else
            {
                GetCookieStatsUnit("Cookie_Level");
                PlayerPrefs.SetFloat("Cookie_Level", Level);
            }
        }
        if(Cards != 0)
        {
            if(PlayerPrefs.HasKey("Cookie_Cards"))
            {
                PlayerPrefs.SetFloat("Cookie_Cards", Cards);
            }
            else
            {
                GetCookieStatsUnit("Cookie_Cards");
                PlayerPrefs.SetFloat("Cookie_Cards", Cards);
            }
        }
        if(Health != 0)
        {
            if(PlayerPrefs.HasKey("Cookie_Health"))
            {
                PlayerPrefs.SetFloat("Cookie_Health", Health);
            }
            else
            {
                GetCookieStatsUnit("Cookie_Health");
                PlayerPrefs.SetFloat("Cookie_Health", Health);
            }
        }
        PlayerPrefs.Save();
    }

    public float GetCookieStatsUnit(string key)
    {
        switch(key)
        {
            case "Cookie_Level":
                if(PlayerPrefs.HasKey(key))
                {
                    return PlayerPrefs.GetFloat(key);
                }
                else 
                {
                    PlayerPrefs.SetFloat(key, 1);
                    return PlayerPrefs.GetFloat(key);
                }
            case "Cookie_Cards":
                if(PlayerPrefs.HasKey(key))
                {
                    return PlayerPrefs.GetFloat(key);
                }
                else 
                {
                    PlayerPrefs.SetFloat(key, 0);
                    return PlayerPrefs.GetFloat(key);
                }
            case "Cookie_Health":
                if(PlayerPrefs.HasKey(key))
                {
                    return PlayerPrefs.GetFloat(key);
                }
                else 
                {
                    PlayerPrefs.SetFloat(key, 150);
                    return PlayerPrefs.GetFloat(key);
                }
            default:
                return 0.0f;
        }
    }

    public string GetCookieName()
    {
        if(PlayerPrefs.HasKey("Cookie_name"))
        {
            return PlayerPrefs.GetString("Cookie_name");
        }
        else 
        {
            PlayerPrefs.SetString("Cookie_name", "Cookie");
            return PlayerPrefs.GetString("Cookie_name");
        }
    }
    
}
