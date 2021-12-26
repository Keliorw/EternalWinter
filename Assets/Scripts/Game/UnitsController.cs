using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class UnitsController : MonoBehaviour
{
    public float Health;
    public GameObject bullet;
    public List<GameObject> enemies;
    public GameObject toAttack;
    public float attackCooldown;
    public bool NotUnit;
    public bool isSpawnSnow;
    private float attackTime;
    public float DamageValue;
    public bool Gun;
    private GameObject Snow;
    private bool isSnow;

    public Animator animator;

    private Save save;

    void Start()
    {
        save = Save.instance;
        animator = GetComponent<Animator>();
        if(isSpawnSnow)
        {
            attackTime = Time.time + attackCooldown;
        }
    }
    private void FixedUpdate() 
    {
        if(Gun == true && !NotUnit)
        {
            if(enemies.Count > 0)
            {
                foreach (GameObject enemy in enemies)
                {
                    if(enemy != null)
                    {
                        var enemyDistance = transform.position - enemy.transform.position;
                        if(enemyDistance.x < 0)
                        {
                            toAttack = enemy;
                        }
                    }
                }
            }
            else if(enemies.Count == 0) 
            {
                toAttack = null;
            }

            if(toAttack != null)
            {
                if(attackTime <= Time.time)
                {
                    GameObject bulletInstance = Instantiate(bullet, transform);
                    bulletInstance.GetComponent<Bullet>().DamageValue = DamageValue;
                    attackTime = Time.time + attackCooldown;
                }
            } 
            else 
            {
                
            }
        }
        else
        {
            if(isSpawnSnow)
            {
                if(attackTime <= Time.time && !isSnow)
                {
                    if (animator) {
                        animator.SetBool("NoCast", true);
                    }
                    Snow = Instantiate(bullet, transform);
                    isSnow = true;
                    
                    
                }
                if(attackTime <= Time.time && Snow == null)
                {
                    attackTime = Time.time + attackCooldown;
                    isSnow = false;
                }
            }
        }
    }

    public void ReceiveDamage(float Damage)
    {
        if(!NotUnit)
        {
            Health -= Damage;
            if (this.gameObject.name == "Gingerman_Game(Clone)") {
                int percent = (int)(Health / save.GetCookieStatsUnit("Cookie_Health") * 100);
                if (percent < 60 && percent > 30) {
                    if (animator) {
                        animator.SetBool("MiddleHP", true);
                    }
                }
                if (percent < 30) {
                    if (animator) {
                        animator.SetBool("MiddleHP", false);
                        animator.SetBool("LowHP", true);
                    }
                }
            }
            if(Health <= 0)
            {
                transform.parent.GetComponent<ObjectContainer>().isFull = false;
                Destroy(this.gameObject);
            }
        }
    }

    public void DestroyEnemy()
    {
        transform.GetComponent<BoxCollider2D>().size = new Vector2(400, 420);
    }

    public void Destroy()
    {
        transform.parent.GetComponent<ObjectContainer>().isFull = false;
        Destroy(this.gameObject);
    }
}

