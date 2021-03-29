using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

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

    //cat hp 추가 -> 병원 가기
    public float CatHP;
    public GameObject Event_hospital;
    public Text textHospital;
    public Image imageHP;




    // #####################################################################################################################
    void Awake()
    {
        toy = GameObject.Find("ToyManager_Toy").GetComponent<ToyManager>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();


    }

    void Start()
    {
        string path = Application.persistentDataPath + "/save.xml";
        if (System.IO.File.Exists(path))
        {
            Load();
        }

        textPlay.text = PlayPrice.ToString();
        textTouch.text = TouchPrice.ToString();
        textWash.text = WashPrice.ToString();

        HungryButton = gm.foodButton;

    }


    void Update()
    {
        
        WashlerpSpeed += Time.deltaTime / (lerpSpeed*24);
        HungrylerpSpeed += Time.deltaTime / (lerpSpeed*2);

        ButtonActiveCheck();

        FunnyStatus();
        WashStatus();
        HungryStatus();
        HPStatus();
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
                PlaylerpSpeed = 0.0f;
            }
        }
    }

    public void _TouchBtton()
    {
        if (gm.heart >= TouchPrice)
        {
            gm.heart -= TouchPrice;

            PlaylerpSpeed = 0.0f;
            

        }
    }

    public void _WashBtton()
    {
        if (gm.heart >= WashPrice)
        {
            gm.heart -= WashPrice;
            WashlerpSpeed = 0.0f;
            
            
        }
    }

    public void _HungryBtton()
    {
        if (HungrylerpSpeed > 0)
        {
            HungrylerpSpeed = 0.0f;
            
        }
    }



    void FunnyStatus()
    {
        if (PlaylerpSpeed<=1)
        {
            PlaylerpSpeed += Time.deltaTime / lerpSpeed;
        }
        if (PlaylerpSpeed > 1)
        {            
            CatHP -= 0.1f;
            PlaylerpSpeed = 1.0f;
            
        }
        imagePlay.fillAmount = Mathf.Lerp(1f, 0f, PlaylerpSpeed);
    }
   
    void WashStatus()
    {
        if (WashlerpSpeed > 1)
        {
            WashlerpSpeed = 1.0f;
            CatHP -= 0.1f;
        }
        imageWash.fillAmount = Mathf.Lerp(0f, 1f, WashlerpSpeed);
    }

    void HungryStatus()
    {
        if (HungrylerpSpeed >1)
        {
            HungrylerpSpeed = 1.0f;
            CatHP -= 0.1f;
        }
        imageHungry.fillAmount = Mathf.Lerp(1f, 0f, HungrylerpSpeed);
    }

    void HPStatus()
    {
        imageHP.fillAmount = Mathf.Lerp(0f, 1f, CatHP);

        if (CatHP <= 0)
        {
            CatHP = 0;
            Hospital();
        }
    }

    void Hospital()
    {
        if (CatHP == 0)
        {
            Event_hospital.SetActive(true);
            textHospital.text = "[" + gm.stringCatInfo_gm + "] 가 아프다.\n병원에 데려가자\n\n진료비 10000";


            if (Input.GetMouseButtonDown(0))
            {
                Event_hospital.SetActive(false);
                gm.heart -= 10000;
                //회복
                CatHP = 1;
                HungrylerpSpeed = 0.5f;
                PlaylerpSpeed = 0.5f;
                WashlerpSpeed = 0.5f;
            }
            
        }
    }

    // #####################################################################################################################

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
        CatHP = saveData.CatHP;

    }

    // #####################################################################################################################
}
