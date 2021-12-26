using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GetSnow : MonoBehaviour, IPointerClickHandler
{    
    public float Speed;
    public bool isBear;
    public float HealthTime;
    private float SpawnTime;
    private bool isClick;
    private Vector3 Target;
    public bool IsIce;

    private Save save;
    
    void Start()
    {
        save = Save.instance;
        isClick = false;
        SpawnTime = Time.time;
    }

    void FixedUpdate()
    {
        if(isClick == true && !IsIce)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target, Speed*Time.deltaTime);
        }
        if(SpawnTime+HealthTime <= Time.time)
        {
            if (isBear) {
                SetAnimation();
            }
            Destroy(this.gameObject);
        }
    }

    private void SetAnimation() {
        if (transform.parent.GetComponent<UnitsController>().animator) {
            transform.parent.GetComponent<UnitsController>().animator.SetBool("NoCast", false);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!IsIce) {
            if (isBear) {
                SetAnimation();
            }
            Transform NewParent = GameObject.FindGameObjectWithTag("ListCard").transform;
            Target = GameObject.FindGameObjectWithTag("SnowTarget").transform.position;
            isClick = true;
            HealthTime += 1000;
            if(!isBear)
            {
                this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
            this.gameObject.transform.SetParent(NewParent);
        } else {
            save.SaveMoney(save.GetMoney() + 1);
            Destroy(this.gameObject);
        }
    }
}
