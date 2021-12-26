using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    private Save save;
    public Text MoneyTextMenu;
    public Text MoneyTextColletctions;
    public Text MoneyTextGift;

    private void Awake() {
        instance = this;
    }
    void Start()
    {
        save = Save.instance;    
    }

    private void Update()
    {
        MoneyTextMenu.text = save.GetMoney().ToString();
        MoneyTextColletctions.text = save.GetMoney().ToString();
        MoneyTextGift.text = save.GetMoney().ToString();
    }

    public void RemoveMoney (float removableMoney) {
        float TempMoney = save.GetMoney() - removableMoney;
        save.SaveMoney(TempMoney);
    }
}
