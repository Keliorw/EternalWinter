using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectContainer : MonoBehaviour
{
    public bool isFull;
    private GameManager gameManager;
    public Image backgroundImage;
    public SpawnPoint spawnPoint;

    public void Start()
    {
        gameManager = GameManager.instance;
    }
    public void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.layer == 6){
            if (!isFull) {
                if(gameManager.draggingObject != null && collision.transform.GetComponent<ObjectDragging>().Deleter == false)
                {
                    gameManager.currentContainer = this.gameObject;
                    backgroundImage.enabled = true;
                }
            } else  {
                if(gameManager.draggingObject != null && collision.transform.GetComponent<ObjectDragging>().Deleter == true)
                {
                    gameManager.currentContainer = this.gameObject;
                    backgroundImage.enabled = true;
                }
            } 
        }
          
    }

    public void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.gameObject.layer != 13)
        {
            gameManager.currentContainer = null;    
            backgroundImage.enabled = false;
        }
    }
}
