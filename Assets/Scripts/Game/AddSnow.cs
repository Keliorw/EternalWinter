using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSnow : MonoBehaviour
{
    [Header("Кол-во даваймых снежинок")]
    public int AmountSnow;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.instance;
    }
    public void OnTriggerEnter2D(Collider2D collision) 
    {
        Destroy(collision.gameObject);
        gameManager.Snow += 10;
    }
}
