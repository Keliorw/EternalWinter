using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float movementSpeed;
    public float DamageValue;

    void FixedUpdate()
    {
        transform.Translate(new Vector3(movementSpeed*Time.deltaTime, 0, 0));
    }

    public void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.layer == 9)
        {
            collision.gameObject.GetComponent<EnemyController>().ReceiveDamage(DamageValue);
            Destroy(this.gameObject);
        }
    }
}
