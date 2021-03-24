using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class ToyManager : MonoBehaviour
{
    public int alpha;
    public long ToyCreatePrice;
    public long ToyIncreaseAmount;
    public long ToyIncreaseLevel;
    public long ToyIncreasePrice;
    public string ToyName;
    public int ToyState;    //0:미설치, 1:설치

    public Text textToyIncreasePrice;
    public Text textToyUpgradePrice;
    public Button ToyIncreaseButton;

    public GameObject prefabToy;


    GameManager gm;

    public Vector2 point;




    // #####################################################################################################################
    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        string path = Application.persistentDataPath + "/save.xml";
        if (System.IO.File.Exists(path))
        {

            Load();
        }

        ToyState = 0;
        if (ToyIncreaseLevel >= 1)
        {
            ToyState = 1;
            Instantiate(prefabToy, point, Quaternion.identity);
        }
    }

    void Update()
    {
        ButtonActiveCheck();
        ToyIncreaseUpdatePanelText();
        ToyIncreaseUpdatePriceText();

    }

    // #####################################################################################################################

    IEnumerator autoClick()
    {

        while (true)
        {
            gm.heart += ToyIncreaseAmount;

            yield return new WaitForSeconds(5);
        }
        
    }

    public void ToyCreateButton()
    {
        
        if (ToyState==0)
        {
            if (gm.heart >= ToyCreatePrice)
            {
                gm.heart -= ToyCreatePrice;
                ToyIncreaseLevel += 1;
                ToyState = 1;
                Instantiate(prefabToy, point, Quaternion.identity);
            }
            StartCoroutine(autoClick());
        }

    }


    public void ToyIncreaseLevelUpgrade()
    {
        

        if (ToyState == 1)
        {
            if (gm.heart >= ToyIncreasePrice)
            {
                gm.heart -= ToyIncreasePrice;
                ToyIncreaseLevel += 1;
                ToyIncreaseAmount += ToyIncreaseLevel * 10 * alpha;
                ToyIncreasePrice += (long)(Mathf.Pow(2, ToyIncreaseLevel) * alpha * alpha);

            }

        }
    }

    void ToyIncreaseUpdatePanelText()
    {
        textToyIncreasePrice.text = ToyName+"Lv." + ToyIncreaseLevel + "\n" +"5초당 " + ToyIncreaseAmount + "개 획득";

    }

    void ToyIncreaseUpdatePriceText()
    {
        
        if (ToyState==0)
        {
            textToyUpgradePrice.text = "설치 <" + ToyCreatePrice.ToString() + ">";
        }

        else if (ToyState==1)
        {
            textToyUpgradePrice.text = ToyIncreasePrice.ToString();
        }
    }



    void ButtonActiveCheck()
    {
        
        if (ToyState==0)
        {
            if (gm.heart >= ToyCreatePrice)
            {
                ToyIncreaseButton.interactable = true;
            }
            else
            {
                ToyIncreaseButton.interactable = false;
            }
        }
        else if(ToyState==1)
        {
            if (gm.heart >= ToyIncreasePrice)
            {
                ToyIncreaseButton.interactable = true;
            }
            else
            {
                ToyIncreaseButton.interactable = false;
            }
        }

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(point, 0.2f);
    }


    // #####################################################################################################################

    void Load()
    {
        
        SaveData saveData = new SaveData();
        string path = Application.persistentDataPath + "/save.xml";
        saveData = XmlManager.XmlLoad<SaveData>(path);
               

        if (this.gameObject.name == "ToyManager_Toy")
        {
            ToyState = saveData.ToyState1;
            alpha = saveData.alpha1;
            ToyCreatePrice = saveData.ToyCreatePrice1;
            ToyIncreaseAmount = saveData.ToyIncreaseAmount1;
            ToyIncreaseLevel = saveData.ToyIncreaseLevel1;
            ToyIncreasePrice = saveData.ToyIncreasePrice1;
            ToyName = saveData.ToyName1;
        }

        else if (this.gameObject.name == "ToyManager_Scratcher")
        {
            ToyState = saveData.ToyState2;
            alpha = saveData.alpha2;
            ToyCreatePrice = saveData.ToyCreatePrice2;
            ToyIncreaseAmount = saveData.ToyIncreaseAmount2;
            ToyIncreaseLevel = saveData.ToyIncreaseLevel2;
            ToyIncreasePrice = saveData.ToyIncreasePrice2;
            ToyName = saveData.ToyName2;
        }
        else if (this.gameObject.name == "ToyManager_Box")
        {
            ToyState = saveData.ToyState3;
            alpha = saveData.alpha3;
            ToyCreatePrice = saveData.ToyCreatePrice3;
            ToyIncreaseAmount = saveData.ToyIncreaseAmount3;
            ToyIncreaseLevel = saveData.ToyIncreaseLevel3;
            ToyIncreasePrice = saveData.ToyIncreasePrice3;
            ToyName = saveData.ToyName3;
        }
        else if (this.gameObject.name == "ToyManager_CatTower")
        {
            ToyState = saveData.ToyState4;
            alpha = saveData.alpha4;
            ToyCreatePrice = saveData.ToyCreatePrice4;
            ToyIncreaseAmount = saveData.ToyIncreaseAmount4;
            ToyIncreaseLevel = saveData.ToyIncreaseLevel4;
            ToyIncreasePrice = saveData.ToyIncreasePrice4;
            ToyName = saveData.ToyName4;
        }

    }
    
    // #####################################################################################################################
    
}