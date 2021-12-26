using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftManager : MonoBehaviour
{
    private Save save;
    private SoundManager soundManager;
    private MoneyManager moneyManager;
    public GameObject OpenGiftPanel;
    public GameObject GiftButton;
    public GameObject GiftImageAnimation;
    public GameObject OpenedGiftPanel;
    public Text CountCardsText;
    public Image GettedCardImage;

    public Text InfoGiftText;
    void Start()
    {
        save = Save.instance;
        soundManager = SoundManager.instance;
        moneyManager = MoneyManager.instance;
        OpenGiftPanel.SetActive(false);
        GiftImageAnimation.SetActive(false);
        OpenedGiftPanel.SetActive(false);
    }

    void Update()
    {
        
    }

    public void ActiveOpenGiftPanel () {
        soundManager.PlaySound();
        if (OpenGiftPanel.activeSelf == true) {
            OpenGiftPanel.SetActive(false);
        } else {
            OpenGiftPanel.SetActive(true);
            UpdateInfoGiftText();
        }
    }

    private void UpdateInfoGiftText() {
        string addInfoGiftText;
        if (save.GetGifts() > 0) {
            addInfoGiftText = "Вы можете открыть подарок!";
        } else {
            addInfoGiftText = "Вы можете купить подарок!";
        }
        InfoGiftText.text = " У вас " + save.GetGifts() + " подарков. " + addInfoGiftText;
    }

    public void OpenGift() {
        if (save.GetGifts() > 0) {
            save.SaveGifts(save.GetGifts() - 1);
            int randomCard = Random.Range(0, save.UnitsCount+1);
            int randomCountCards = Random.Range(15, 30);
            string NameUnit = "";
            switch(randomCard)
            {
                case 0:
                    save.SaveBearUnit(-1, save.GetBearStatsUnit("Bear_Cards") + randomCountCards);
                    NameUnit = save.GetBearName();
                    break;
                case 1:
                    save.SaveElfUnit(-1, save.GetElfStatsUnit("Elf_Cards") + randomCountCards);
                    NameUnit = save.GetElfName();
                    break;
                case 2:
                    save.SavePenguinUnit(-1, save.GetPenguinStatsUnit("Penguin_Cards") + randomCountCards);
                    NameUnit = save.GetPenguinName();
                    break;
                case 3:
                    save.SaveCookieUnit(-1, save.GetCookieStatsUnit("Cookie_Cards") + randomCountCards);
                    NameUnit = save.GetCookieName();
                    break;
            }            
            OpenGiftPanel.SetActive(false);
            GiftButton.SetActive(false);
            GiftImageAnimation.SetActive(true);
            CountCardsText.text = randomCountCards + " карт";
            GettedCardImage.sprite = Resources.Load<Sprite>(NameUnit + "Big");
            StartCoroutine(waiter());
        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2);
        GiftImageAnimation.SetActive(false);
        OpenedGiftPanel.SetActive(true);
    }

    public void BuyGift() {
        if (save.GetMoney() >= 10) {
            float TempMoney = save.GetMoney() - 10;
            save.SaveMoney(TempMoney);
            int TempGifts = save.GetGifts() + 1;
            save.SaveGifts(TempGifts);
            UpdateInfoGiftText();     
        }
    }

    public void ConfirmButton () {
        OpenedGiftPanel.SetActive(false);
        GiftButton.SetActive(true);
    }
}
