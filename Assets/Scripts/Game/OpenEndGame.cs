using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEndGame : MonoBehaviour
{
    public GameObject EndGameMenu;

    public void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.layer == 9)
        {
            Time.timeScale = 0;
            EndGameMenu.SetActive(true);
        }
    }
}
