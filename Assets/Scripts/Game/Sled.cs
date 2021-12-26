using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sled : MonoBehaviour
{
    public float Speed;
    private bool isStart;

    void Start()
    {
        isStart = false;
    }

    void FixedUpdate()
    {
        if(isStart)
        {
            transform.Translate(new Vector3(Speed*Time.deltaTime, 0, 0));
        }
    }
    public void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.layer == 9)
        {
            isStart = true;
        }
        if(collision.gameObject.layer == 13)
        {
            Destroy(this.gameObject);
        }
    }
}
