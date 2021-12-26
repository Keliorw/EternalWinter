using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Globalization;

public class CardsManager : MonoBehaviour
{
    private Save save;
    private SoundManager soundManager;
    private MoneyManager moneyManager;

    public Scrollbar CardsProgressScrollbar;
    public GameObject SelectCardPanel;
    public Text UpgradeButtonText;
    public GameObject UpgradeButtonObject;
    public GameObject ScrollBarObject;
    public Image SelectCardImage;
    public Text LevelText;
    public Text DamageText;
    public Text AttackSpeedText;
    public Text HealthText;
    public Text GeneratorText;
    public Text PriceText;
    public Text CardsText;

    private float PriceToUpgrade;
    private float CardsToUpgrade;
    private string CurrentId;

    private void Start()
    {
        SelectCardPanel.SetActive(false);
        save = Save.instance;
        soundManager = SoundManager.instance;
        moneyManager = MoneyManager.instance;
    }

    public void SelectCard(string id){
        soundManager.PlaySound();
        CurrentId = id;
        SelectCardPanel.SetActive(true);
        float CardsUnit = 0.0f;
        switch(id)
        {
            case "Bear":
                CalculatePriceToUpgrade(save.GetBearStatsUnit("Bear_Level"));
                CalculateCardsToUpgrade(save.GetBearStatsUnit("Bear_Level"));
                CardsUnit = save.GetBearStatsUnit("Bear_Cards");
                LevelText.text = "Уровень: " + save.GetBearStatsUnit("Bear_Level").ToString();
                DamageText.text = "Урон: Нет урона";
                HealthText.text = "Здоровье: " + save.GetBearStatsUnit("Bear_Health").ToString();
                AttackSpeedText.text = "Создание снега: " + save.GetBearStatsUnit("Bear_AttackSpeed").ToString() + "сек.";
                GeneratorText.text = "";
                PriceText.text = "Стоимость: 10";
                CardsText.text = save.GetBearStatsUnit("Bear_Cards").ToString() + "/" + CardsToUpgrade.ToString();
                UpgradeButtonText.text = PriceToUpgrade.ToString();
                CardsProgressScrollbar.size = CardsUnit / CardsToUpgrade;
                break;
            case "Penguin":
                CalculatePriceToUpgrade(save.GetPenguinStatsUnit("Penguin_Level"));
                CalculateCardsToUpgrade(save.GetPenguinStatsUnit("Penguin_Level"));
                CardsUnit = save.GetPenguinStatsUnit("Penguin_Cards");
                LevelText.text = "Уровень: " + save.GetPenguinStatsUnit("Penguin_Level").ToString();
                DamageText.text = "Урон: " + save.GetPenguinStatsUnit("Penguin_Damage").ToString();
                HealthText.text = "Здоровье: " + save.GetPenguinStatsUnit("Penguin_Health").ToString();
                AttackSpeedText.text = "Скорость атаки: " + save.GetPenguinStatsUnit("Penguin_AttackSpeed").ToString();
                GeneratorText.text = " ";
                PriceText.text = "Стоимость: 40";
                CardsText.text = save.GetPenguinStatsUnit("Penguin_Cards").ToString() + "/" + CardsToUpgrade.ToString();
                UpgradeButtonText.text = PriceToUpgrade.ToString();
                CardsProgressScrollbar.size = CardsUnit / CardsToUpgrade;
                break;
            case "Elf":
                CalculatePriceToUpgrade(save.GetElfStatsUnit("Elf_Level"));
                CalculateCardsToUpgrade(save.GetElfStatsUnit("Elf_Level"));
                CardsUnit = save.GetElfStatsUnit("Elf_Cards");
                LevelText.text = "Уровень: " + save.GetElfStatsUnit("Elf_Level").ToString();
                DamageText.text = "Урон: " + save.GetElfStatsUnit("Elf_Damage").ToString();
                HealthText.text = "Здоровье: " + save.GetElfStatsUnit("Elf_Health").ToString();
                AttackSpeedText.text = "Скорость атаки: " + save.GetElfStatsUnit("Elf_AttackSpeed").ToString();
                GeneratorText.text = " ";
                PriceText.text = "Стоимость: 80";
                CardsText.text = save.GetElfStatsUnit("Elf_Cards").ToString() + "/" + CardsToUpgrade.ToString();
                UpgradeButtonText.text = PriceToUpgrade.ToString();
                CardsProgressScrollbar.size = CardsUnit / CardsToUpgrade;
                break;
            case "Cookie":
                CalculatePriceToUpgrade(save.GetCookieStatsUnit("Cookie_Level"));
                CalculateCardsToUpgrade(save.GetCookieStatsUnit("Cookie_Level"));
                CardsUnit = save.GetCookieStatsUnit("Cookie_Cards");
                LevelText.text = "Уровень: " + save.GetCookieStatsUnit("Cookie_Level").ToString();
                DamageText.text = "Урон: Нет урона";
                HealthText.text = "Здоровье: " + save.GetCookieStatsUnit("Cookie_Health").ToString();
                AttackSpeedText.text = "Скорость атаки: нету";
                GeneratorText.text = " ";
                PriceText.text = "Стоимость: 30";
                CardsText.text = save.GetCookieStatsUnit("Cookie_Cards").ToString() + "/" + CardsToUpgrade.ToString();
                UpgradeButtonText.text = PriceToUpgrade.ToString();
                CardsProgressScrollbar.size = CardsUnit / CardsToUpgrade;
                break;
            case "Gift":
                UpgradeButtonObject.SetActive(false);
                ScrollBarObject.SetActive(false);
                LevelText.text = "Делает Бум!";
                DamageText.text = "Урон: бесконечность";
                HealthText.text = " ";
                AttackSpeedText.text = " ";
                GeneratorText.text = " ";
                PriceText.text = "Стоимость: 150";
                CardsText.text = " ";
                break;
            default:
                Debug.LogError("Null Unit id in list: " + id);
                break;
        }
        SelectCardImage.sprite = Resources.Load<Sprite>(id + "Big");
    }

    private void CalculatePriceToUpgrade (float Level) {
        PriceToUpgrade = Level * Level * 5;
    }

    private void CalculateCardsToUpgrade (float Level) {
        CardsToUpgrade = Level * Level * 10;
    }

    public void UpgradeButton () {
        switch(CurrentId)
        {
            case "Bear":
                if (save.GetBearStatsUnit("Bear_Cards") >= CardsToUpgrade && save.GetMoney() >= PriceToUpgrade) 
                {
                    soundManager.PlaySound();
                    save.SaveBearUnit(save.GetBearStatsUnit("Bear_Level")+1, save.GetBearStatsUnit("Bear_Cards")-CardsToUpgrade, 0, save.GetBearStatsUnit("Bear_Health")*Mathf.Pow(1.11f, save.GetBearStatsUnit("Bear_Level")+1));
                    moneyManager.RemoveMoney(PriceToUpgrade);
                    SelectCard(CurrentId);
                }
                break;
            case "Penguin":
                if (save.GetPenguinStatsUnit("Penguin_Cards") >= CardsToUpgrade && save.GetMoney() >= PriceToUpgrade) 
                {
                    soundManager.PlaySound();
                    save.SavePenguinUnit(save.GetPenguinStatsUnit("Penguin_Level")+1, save.GetPenguinStatsUnit("Penguin_Cards")-CardsToUpgrade, 0, save.GetPenguinStatsUnit("Penguin_Health")*Mathf.Pow(1.11f, save.GetPenguinStatsUnit("Penguin_Level")+1), save.GetPenguinStatsUnit("Penguin_Damage")*Mathf.Pow(1.07f, save.GetPenguinStatsUnit("Penguin_Level")+1));
                    moneyManager.RemoveMoney(PriceToUpgrade);
                    SelectCard(CurrentId);
                }
                break;
            case "Elf":
                if (save.GetElfStatsUnit("Elf_Cards") >= CardsToUpgrade && save.GetMoney() >= PriceToUpgrade) 
                {
                    soundManager.PlaySound();
                    save.SaveElfUnit(save.GetElfStatsUnit("Elf_Level")+1, save.GetElfStatsUnit("Elf_Cards")-CardsToUpgrade, 0, save.GetElfStatsUnit("Elf_Health")*Mathf.Pow(1.11f, save.GetElfStatsUnit("Elf_Level")+1), save.GetElfStatsUnit("Elf_Damage")*Mathf.Pow(1.07f, save.GetElfStatsUnit("Elf_Level")+1));
                    moneyManager.RemoveMoney(PriceToUpgrade);
                    SelectCard(CurrentId);
                }
                break;
            case "Cookie":
                if (save.GetCookieStatsUnit("Cookie_Cards") >= CardsToUpgrade && save.GetMoney() >= PriceToUpgrade) 
                {
                    soundManager.PlaySound();
                    save.SaveCookieUnit(save.GetCookieStatsUnit("Cookie_Level")+1, save.GetCookieStatsUnit("Cookie_Cards")-CardsToUpgrade, save.GetCookieStatsUnit("Cookie_Health")*Mathf.Pow(1.11f, save.GetCookieStatsUnit("Bear_Level")+1));
                    moneyManager.RemoveMoney(PriceToUpgrade);
                    SelectCard(CurrentId);
                }
                break;
            default:
                Debug.LogError("Null Unit id in list: " + CurrentId);
                break;
        }
    }

    public void BackButton() {
        soundManager.PlaySound();
        SelectCardPanel.SetActive(false);
        UpgradeButtonObject.SetActive(true);
        ScrollBarObject.SetActive(true);
    }
}
