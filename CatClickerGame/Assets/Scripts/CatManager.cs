using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CatManager : MonoBehaviour
{
    ToyManager toy;
    GameManager gm;


    public int PlayPrice;
    public Button PlayButton;
    public Text textPlay;
    public Image imagePlay;
    public float PlaylerpSpeed;

    //touch시 funny 증가
    public int TouchPrice;
    public Button TouchButton;
    public Text textTouch;
    

    public int WashPrice;
    public Button WashButton;
    public Text textWash;
    public Image imageWash;
    public float WashlerpSpeed;

    //gm에서 받아와서 밥주면 배부름 증가
    public Button HungryButton;
    public Image imageHungry;
    public float HungrylerpSpeed;

    public float lerpSpeed;




    // #####################################################################################################################

    void Start()
    {
        //Load();
        

        toy = GameObject.Find("ToyManager_Toy").GetComponent<ToyManager>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        textPlay.text = PlayPrice.ToString();
        textTouch.text = TouchPrice.ToString();
        textWash.text = WashPrice.ToString();

        HungryButton = gm.foodButton;

    }


    void Update()
    {
        PlaylerpSpeed += Time.deltaTime / lerpSpeed;
        WashlerpSpeed += Time.deltaTime / lerpSpeed;
        HungrylerpSpeed += Time.deltaTime / lerpSpeed*0.6f;

        ButtonActiveCheck();

        FunnyStatus();
        WashStatus();
        HungryStatus();
    }

    // #####################################################################################################################

    void ButtonActiveCheck()
    {

        if (gm.heart >= PlayPrice)
        {
            if (GameObject.Find("prefab_Toy(Clone)") == true)
            {
                PlayButton.interactable = true;
            }
        }
        else
        {
            PlayButton.interactable = false;
        }                        


        if (gm.heart >= TouchPrice)
        {
            TouchButton.interactable = true;
        }
        else
        {
            TouchButton.interactable = false;
        }


        if (gm.heart >= WashPrice)
        {
            WashButton.interactable = true;
        }
        else
        {
            WashButton.interactable = false;
        }
    }

    public void _PlayBtton()
    {
        if (gm.heart >= PlayPrice)
        {

            gm.heart -= PlayPrice;

            PlaylerpSpeed -= 0.2f;
            if (PlaylerpSpeed < 0)
            {
                PlaylerpSpeed = 0;
            }
        }
    }

    public void _TouchBtton()
    {
        if (gm.heart >= TouchPrice)
        {
            gm.heart -= TouchPrice;

            PlaylerpSpeed -= 0.2f;
            if (PlaylerpSpeed < 0)
            {
                PlaylerpSpeed = 0;                
            }

        }
    }

    public void _WashBtton()
    {
        if (gm.heart >= WashPrice)
        {
            gm.heart -= WashPrice;
            WashlerpSpeed -= 0.2f;
            if (WashlerpSpeed < 0)
            {
                WashlerpSpeed = 0;                
            }
        }
    }

    public void _HungryBtton()
    {
        if (HungrylerpSpeed > 0)
        {
            HungrylerpSpeed -= 0.2f;
            if (HungrylerpSpeed < 0)
            {
                HungrylerpSpeed = 0.0f;
            }
        }
    }



    void FunnyStatus()
    {        
        imagePlay.fillAmount = Mathf.Lerp(1f, 0f, PlaylerpSpeed);
    }
   
    void WashStatus()
    {
        imageWash.fillAmount = Mathf.Lerp(0f, 1f, WashlerpSpeed);
    }

    void HungryStatus()
    {
        imageHungry.fillAmount = Mathf.Lerp(1f, 0f, HungrylerpSpeed);
    }

    // #####################################################################################################################
    /*
    void Save()
    {
        SaveData saveData = new SaveData();

        saveData.PlayPrice = PlayPrice;
        saveData.PlaylerpSpeed = PlaylerpSpeed;
        saveData.TouchPrice = TouchPrice;
        saveData.WashPrice = WashPrice;
        saveData.WashlerpSpeed = WashlerpSpeed;
        saveData.HungrylerpSpeed = HungrylerpSpeed;
        saveData.lerpSpeed = lerpSpeed;

    string path = Application.persistentDataPath + "/save.xml";
        XmlManager.XmlSave<SaveData>(saveData, path);
    }
    */
    void Load()
    {
        SaveData saveData = new SaveData();
        string path = Application.persistentDataPath + "/save.xml";
        saveData = XmlManager.XmlLoad<SaveData>(path);

        PlayPrice = saveData.PlayPrice;
        PlaylerpSpeed = saveData.PlaylerpSpeed;
        TouchPrice = saveData.TouchPrice;
        WashPrice = saveData.WashPrice;
        WashlerpSpeed = saveData.WashlerpSpeed;
        HungrylerpSpeed = saveData.HungrylerpSpeed;
        lerpSpeed = saveData.lerpSpeed;

    }

    // #####################################################################################################################
}
