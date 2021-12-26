using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;

public class GameManager : MonoBehaviour
{
    public GameObject draggingObject;
    public GameObject currentContainer;
    public static GameManager instance;

    [Header("Объекты открывающихся полей")]
    public GameObject MenuPause;
    [Header("Кол-во снежинок")]
    public int Snow;
    [Header("Кол-во снежинок выдающихся на старте")]
    public int StartSnow; 
    public GameObject TextSnow;

    private Save save;
    private void Awake()
    {
        instance = this;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        Snow = StartSnow;
    }

    private void Start() {
        save = Save.instance;
    }

    private void FixedUpdate() 
    {
        TextSnow.GetComponent<Text>().text = Snow.ToString();    
    }

    public void PlaceObject()
    {
        if(draggingObject != null && currentContainer != null && !draggingObject.GetComponent<ObjectDragging>().Deleter)
        {
            GameObject unitGame = Instantiate(draggingObject.GetComponent<ObjectDragging>().card.object_Game, currentContainer.transform);
            unitGame.GetComponent<UnitsController>().enemies = currentContainer.GetComponent<ObjectContainer>().spawnPoint.enemies;
            currentContainer.GetComponent<ObjectContainer>().isFull = true;            
            switch(unitGame.transform.name) {
                case "Bear_Game(Clone)":
                    unitGame.GetComponent<UnitsController>().Health = save.GetBearStatsUnit("Bear_Health");
                    break;
                case "Gingerman_Game(Clone)":
                    unitGame.GetComponent<UnitsController>().Health = save.GetCookieStatsUnit("Cookie_Health");
                    break;
                case "ObjectOne_Game(Clone)":
                    unitGame.GetComponent<UnitsController>().Health = save.GetPenguinStatsUnit("Penguin_Health");
                    unitGame.GetComponent<UnitsController>().DamageValue = save.GetPenguinStatsUnit("Penguin_Damage");
                    break;
                case "ObjectTwo_Game(Clone)":
                    unitGame.GetComponent<UnitsController>().Health = save.GetPenguinStatsUnit("Elf_Health");
                    unitGame.GetComponent<UnitsController>().DamageValue = save.GetPenguinStatsUnit("Elf_Damage");
                    break;
            }
        }
    }

    private void PauseMenu(string status)
    {
        if(status == "open")
        {
            MenuPause.SetActive(true);
        }
        else
        {
            MenuPause.SetActive(false);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PauseMenu("open");
    }

    public void Continue()
    {
        Time.timeScale = 1;
        PauseMenu("close");
    }

    public void BackMenu(int id)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(id);
    }

    public void Settings()
    {

    }

    public void RestartLevel(int id)
    {
        SceneManager.LoadScene(id);
    }
}
