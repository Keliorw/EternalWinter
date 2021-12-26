using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjectCard : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject object_Drag;
    public GameObject object_Game;
    public int Prise;
    public float Cooldown;
    public Canvas canvas;
    private GameObject object_Drag_Instance;
    private GameManager gameManager;
    private bool HavePrise;

    private Color Active;
    private Color NotActive;
    private float TimeCoolDown;
    private Text TextCooldown;

    public void Start()
    {
        gameManager = GameManager.instance;
        Active = new Color32(255, 255, 255, 255);
        NotActive = new Color32(82, 82, 82, 255);
        TextCooldown = transform.GetChild(2).transform.GetComponent<Text>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(HavePrise == true)
        {
            object_Drag_Instance.transform.position = Input.mousePosition;
        }
        
    }

    void Update()
    {
        if(TimeCoolDown > 0)
        {
            TextCooldown.text = TimeCoolDown.ToString();
        }
        else 
        {
            TextCooldown.text = "";
        }
        
    }

    void FixedUpdate() 
    {
        this.gameObject.transform.GetChild(0).GetComponent<Text>().text = Prise.ToString();     
        if(gameManager.Snow >= Prise && TimeCoolDown <= 0)
        {
            this.gameObject.transform.GetComponent<Image>().color = Active;
        }
        else 
        {
            this.gameObject.transform.GetComponent<Image>().color = NotActive;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(gameManager.Snow >= Prise && TimeCoolDown <= 0)
        {
            object_Drag_Instance = Instantiate(object_Drag, canvas.transform);
            object_Drag_Instance.transform.position = Input.mousePosition;
            object_Drag_Instance.GetComponent<ObjectDragging>().card = this;
            
            gameManager.draggingObject = object_Drag_Instance;
            HavePrise = true;
        }
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(HavePrise == true && gameManager.currentContainer != null && !object_Drag_Instance.GetComponent<ObjectDragging>().Deleter)
        {
            gameManager.PlaceObject();
            gameManager.draggingObject = null;
            Destroy(object_Drag_Instance);
            HavePrise = false;
            gameManager.Snow -= Prise;
            TimeCoolDown = Cooldown;
            StartCoroutine(ExecuteAfterTime());
        }
        else 
        {
            if(HavePrise == true)
            {
                if(object_Drag_Instance.GetComponent<ObjectDragging>().Deleter && gameManager.currentContainer != null)
                {
                    gameManager.currentContainer.GetComponent<ObjectContainer>().isFull = false;
                    gameManager.currentContainer.transform.GetChild(0).GetComponent<UnitsController>().Destroy();
                    gameManager.draggingObject = null;
                    Destroy(object_Drag_Instance);
                }
                else
                {
                    gameManager.draggingObject = null;
                    Destroy(object_Drag_Instance);
                }
            }
        }
    }

    IEnumerator ExecuteAfterTime()
    {
        if(TimeCoolDown > 0)
        {
            TimeCoolDown -= 1;
            yield return new WaitForSeconds(1.0f);
            StartCoroutine(ExecuteAfterTime());
        }
        yield return 0;
    }
}
