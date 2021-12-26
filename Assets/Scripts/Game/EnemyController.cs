using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float Health;
    public float DamageValue;
    public float DamageCooldown;
    public float movementSpeed;
    private bool isStopped;
    private float ColdTime;
    private bool isCold;
    public GameObject Ice;

    public Animator animator;

    void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if(!isStopped)
        {
            transform.Translate(new Vector3((movementSpeed * -1)*Time.deltaTime, 0, 0));
        }
        if(Time.time >= ColdTime && isCold)
        {
            isCold = false;
            movementSpeed *= 2;
            this.gameObject.transform.GetChild(0).transform.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.layer == 8)
        {
            StartCoroutine(Attack(collision));
            isStopped = true;
        }

        if(collision.gameObject.layer == 11 || collision.gameObject.layer == 12 || collision.gameObject.tag == "GiftBoom")
        {
            transform.parent.GetComponent<SpawnPoint>().enemies.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
        if(collision.gameObject.layer == 10)
        {
            if(!isCold)
            { 
                movementSpeed /= 2;
            }
            ColdTime = Time.time+5;
            isCold = true;
            this.gameObject.transform.GetChild(0).transform.GetComponent<Image>().color = new Color32(72, 108, 207, 255);
            
        }
    }
    IEnumerator Attack(Collider2D collision)
    {
        if(collision == null)
        {
            if (animator) {
                animator.SetBool("IsEating", false);
            }
            isStopped = false;
        } 
        else
        {
            if (animator) {
                animator.SetBool("IsEating", true);
            }
            collision.gameObject.GetComponent<UnitsController>().ReceiveDamage(DamageValue);
            yield return new WaitForSeconds(DamageCooldown);
            StartCoroutine(Attack(collision));
        }
    }

    public void ReceiveDamage(float Damage)
    {
        if(Health - Damage <= 0)
        {
            Drop();
            transform.parent.GetComponent<SpawnPoint>().enemies.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
        else 
        {
            Health -= Damage;
        }
    }

    public void Drop() {
        int randomDropPercent = Random.Range(0, 100);
        if (randomDropPercent < 30) {
            GameObject newIce = Instantiate(Ice, transform);
            newIce.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        }
    }
}
