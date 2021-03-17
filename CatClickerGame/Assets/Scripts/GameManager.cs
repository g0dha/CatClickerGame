using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public long heart;
    public long heartIncreaseAmount;
    public long heartIncreaseLevel;
    public long heartIncreasePrice;
    public Text textHeart;
    public Text textHeartIncreasePrice;
    public Text textHeartUpgradePrice;
    public Button HeartIncreaseButton;

    public GameObject prefabHeart;

    public long foodPrice;
    public Button foodButton;
    public Text textFoodPrice;

    public GameObject prefabFoodDish;
    public int food_lifeTime;

    public Button adButton;
    public float leftTime;
    public float backup_leftTime;
    public Text textleftTime;

    public GameObject Panel_Exit;

    public string stringCatInfo_gm;
    public Text CatInfo;

    ADManager adm;
    ToyManager tm1;
    ToyManager tm2;
    ToyManager tm3;
    ToyManager tm4;
    EventManager em;
    CatManager cm;




    // #####################################################################################################################
    void Awake()
    {
        heartIncreaseAmount = 1;
        heartIncreaseLevel = 1;
        heartIncreasePrice = 10;
        foodPrice = 100;
        food_lifeTime = 30;
        backup_leftTime = 300;
    }

    void Start()
    {
        Load();


        //PlayerPrefs.SetString("GameStartTime", System.DateTime.Now.ToString());

        adm = GameObject.Find("ADManager").GetComponent<ADManager>();
        tm1 = GameObject.Find("ToyManager_Toy").GetComponent<ToyManager>();
        tm2 = GameObject.Find("ToyManager_Scratcher").GetComponent<ToyManager>();
        tm3 = GameObject.Find("ToyManager_Box").GetComponent<ToyManager>();
        tm4 = GameObject.Find("ToyManager_CatTower").GetComponent<ToyManager>();
        em = GameObject.Find("EventManager").GetComponent<EventManager>();
        cm = GameObject.Find("CatManager").GetComponent<CatManager>();

        //Debug.Log(tm1.alpha);
        //Debug.Log(tm2.alpha);

        
        CatInfo.text = stringCatInfo_gm;
        /*if (PlayerPrefs.GetInt("Gender") == 1)
        {
            CatInfo.text = PlayerPrefs.GetString("Name") + "  /  수컷";
        }
        else if (PlayerPrefs.GetInt("Gender") == 2)
        {
            CatInfo.text = PlayerPrefs.GetString("Name") + "  /  암컷";
        }*/

        leftTime = 0f;

    }

    


    void Update()
    {
        ShowInfo();

        HeartIncrease();
        HeartIncreaseUpdatePanelText();
        HeartIncreaseUpdatePriceText();

        ButtonActiveCheck();

        _textFoodPrice();

        ExitGame();


    }




    // #####################################################################################################################

    void ShowInfo()
    {
        if (heart == 0)
            textHeart.text = "0";
        else
            textHeart.text = heart.ToString("######");
    }

    void HeartIncrease()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject(0))
            {
                heart += heartIncreaseAmount;
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(prefabHeart, mousePosition, Quaternion.identity);
            }
        }
    }

    public void HeartIncreaseLevelUpgrade()
    {
        if (heart >= heartIncreasePrice)
        {
            heart -= heartIncreasePrice;
            heartIncreaseLevel += 1;
            heartIncreaseAmount += (long)(heartIncreaseLevel * 3.3);
            heartIncreasePrice += (long)Mathf.Pow(3, heartIncreaseLevel) * 5;
        }
    }

    void HeartIncreaseUpdatePanelText()
    {
        textHeartIncreasePrice.text = "Lv." + heartIncreaseLevel + "\n" + "클릭시 " + heartIncreaseAmount + "개 획득";

    }

    void HeartIncreaseUpdatePriceText()
    {
        textHeartUpgradePrice.text = heartIncreasePrice.ToString();
    }

    // #####################################################################################################################

    void ButtonActiveCheck()
    {
        if (heart >= foodPrice && (GameObject.Find(prefabFoodDish.name + "(Clone)") == false))
        {
            foodButton.interactable = true;
        }
        else
        {
            foodButton.interactable = false;
        }

        if (heart >= heartIncreasePrice)
        {
            HeartIncreaseButton.interactable = true;
        }
        else
        {
            HeartIncreaseButton.interactable = false;
        }

        if (leftTime > 0f)
        {
            adButton.interactable = false;
        }
        else
        {
            adButton.interactable = true;
            textleftTime.text = "광고보기";
        }

    }

    // #####################################################################################################################

    public void feedPrice()
    {
        if (heart >= foodPrice && (GameObject.Find(prefabFoodDish.name + "(Clone)") == false))
        {
            heart -= foodPrice;
            foodPrice = 100 * heartIncreaseLevel;
            ChangeSprite_Food();
        }


    }

    void ChangeSprite_Food()
    {
        if (GameObject.Find(prefabFoodDish.name + "(Clone)") == false)
        {
            Vector2 dishSpot = GameObject.Find("Image_dish").transform.position;
            float spotX = dishSpot.x;
            float spotY = dishSpot.y;

            Instantiate(prefabFoodDish, new Vector2(spotX, spotY), Quaternion.identity);
            Destroy(GameObject.Find(prefabFoodDish.name + "(Clone)"), food_lifeTime);
        }

    }

    void _textFoodPrice()
    {
        textFoodPrice.text = "밥 <" + foodPrice + ">";
    }

    // #####################################################################################################################

    public void showad()
    {
        StartCoroutine("rewardVideo");
    }

    IEnumerator rewardVideo()
    {
        if (adButton.interactable == true)
        {
            adm.Show_RewardVideo();
            leftTime = backup_leftTime;

            StartCoroutine("decreaseTime");


            yield return null;
        }
        else
        {
            yield return null;
        }
    }

    IEnumerator decreaseTime()
    {
        while (leftTime > 0)
        {
            //adButton.interactable = false;
            leftTime -= Time.deltaTime;
            textleftTime.text = Mathf.Round(leftTime).ToString();
            yield return null;
        }

    }

    // #####################################################################################################################

    void ExitGame()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0f;     //시간정지
                Panel_Exit.SetActive(true);
            }
        }
    }

    public void Exit_Yes()
    {
       
        Save();
        Debug.Log("save clear");
        Application.Quit();
        
    }

    public void Exit_No()
    {
        Time.timeScale = 1f;
        Panel_Exit.SetActive(false);
    }


    // #####################################################################################################################
    
    void Save()
    {
        SaveData saveData = new SaveData();

        //GameManager
        saveData.heart = heart;
        saveData.heartIncreaseAmount = heartIncreaseAmount;
        saveData.heartIncreaseLevel = heartIncreaseLevel;
        saveData.heartIncreasePrice = heartIncreasePrice;
        saveData.foodPrice = foodPrice;
        saveData.food_lifeTime = food_lifeTime;
        saveData.leftTime = leftTime;
        saveData.backup_leftTime = backup_leftTime;

        //ToyManager_Toy
        saveData.alpha1 = tm1.alpha;
        saveData.ToyCreatePrice1 = tm1.ToyCreatePrice;
        saveData.ToyIncreaseAmount1 = tm1.ToyIncreaseAmount;
        saveData.ToyIncreaseLevel1 = tm1.ToyIncreaseLevel;
        saveData.ToyIncreasePrice1 = tm1.ToyIncreasePrice;
        saveData.ToyName1 = tm1.ToyName;

        //ToyManager_Scratcher
        saveData.alpha2 = tm2.alpha;
        saveData.ToyCreatePrice2 = tm2.ToyCreatePrice;
        saveData.ToyIncreaseAmount2 = tm2.ToyIncreaseAmount;
        saveData.ToyIncreaseLevel2 = tm2.ToyIncreaseLevel;
        saveData.ToyIncreasePrice2 = tm2.ToyIncreasePrice;
        saveData.ToyName2 = tm2.ToyName;

        //ToyManager_Box
        saveData.alpha3 = tm3.alpha;
        saveData.ToyCreatePrice3 = tm3.ToyCreatePrice;
        saveData.ToyIncreaseAmount3 = tm3.ToyIncreaseAmount;
        saveData.ToyIncreaseLevel3 = tm3.ToyIncreaseLevel;
        saveData.ToyIncreasePrice3 = tm3.ToyIncreasePrice;
        saveData.ToyName3 = tm3.ToyName;

        //ToyManager_CatTower
        saveData.alpha4 = tm4.alpha;
        saveData.ToyCreatePrice4 = tm4.ToyCreatePrice;
        saveData.ToyIncreaseAmount4 = tm4.ToyIncreaseAmount;
        saveData.ToyIncreaseLevel4 = tm4.ToyIncreaseLevel;
        saveData.ToyIncreasePrice4 = tm4.ToyIncreasePrice;
        saveData.ToyName4 = tm4.ToyName;

        //EventManager
        saveData.RandomNumber = em.RandomNumber;
        saveData.RandomTime_1 = em.RandomTime_1;
        saveData.RandomTime_2 = em.RandomTime_2;
        saveData.RandomTime_3 = em.RandomTime_3;

        //ADManager
        saveData.reward_dia = adm.reward_dia;

        //CatManager
        saveData.PlayPrice = cm.PlayPrice;
        saveData.PlaylerpSpeed = cm.PlaylerpSpeed;
        saveData.TouchPrice = cm.TouchPrice;
        saveData.WashPrice = cm.WashPrice;
        saveData.WashlerpSpeed = cm.WashlerpSpeed;
        saveData.HungrylerpSpeed = cm.HungrylerpSpeed;
        saveData.lerpSpeed = cm.lerpSpeed;


        string path = Application.persistentDataPath + "/save.xml";
        XmlManager.XmlSave<SaveData>(saveData, path);
    }

    void Load()
    {
        SaveData saveData = new SaveData();
        string path = Application.persistentDataPath + "/save.xml";
        saveData = XmlManager.XmlLoad<SaveData>(path);


        stringCatInfo_gm = saveData.stringCatInfo;
        //Debug.Log(stringCatInfo_gm);

        //GameManager
        heart = saveData.heart;
        heartIncreaseAmount = saveData.heartIncreaseAmount;
        heartIncreaseLevel = saveData.heartIncreaseLevel;
        heartIncreasePrice = saveData.heartIncreasePrice;
        foodPrice = saveData.foodPrice;
        food_lifeTime = saveData.food_lifeTime;
        leftTime = saveData.leftTime;
        backup_leftTime = saveData.backup_leftTime;

        /*
        //ToyManager_Toy
        tm1.alpha = saveData.alpha1;
        tm1.ToyCreatePrice = saveData.ToyCreatePrice1;
        tm1.ToyIncreaseAmount = saveData.ToyIncreaseAmount1;
        tm1.ToyIncreaseLevel = saveData.ToyIncreaseLevel1;
        tm1.ToyIncreasePrice = saveData.ToyIncreasePrice1;
        tm1.ToyName = saveData.ToyName1;
        
        //ToyManager_Scratcher
        tm2.alpha = saveData.alpha2;
        tm2.ToyCreatePrice = saveData.ToyCreatePrice2;
        tm2.ToyIncreaseAmount = saveData.ToyIncreaseAmount2;
        tm2.ToyIncreaseLevel = saveData.ToyIncreaseLevel2;
        tm2.ToyIncreasePrice = saveData.ToyIncreasePrice2;
        tm2.ToyName = saveData.ToyName2;

        //ToyManager_Box
        tm3.alpha = saveData.alpha3;
        tm3.ToyCreatePrice = saveData.ToyCreatePrice3;
        tm3.ToyIncreaseAmount = saveData.ToyIncreaseAmount3;
        tm3.ToyIncreaseLevel = saveData.ToyIncreaseLevel3;
        tm3.ToyIncreasePrice = saveData.ToyIncreasePrice3;
        tm3.ToyName = saveData.ToyName3;

        //ToyManager_CatTower
        tm4.alpha = saveData.alpha4;
        tm4.ToyCreatePrice = saveData.ToyCreatePrice4;
        tm4.ToyIncreaseAmount = saveData.ToyIncreaseAmount4;
        tm4.ToyIncreaseLevel = saveData.ToyIncreaseLevel4;
        tm4.ToyIncreasePrice = saveData.ToyIncreasePrice4;
        tm4.ToyName = saveData.ToyName4;
        

        //EventManager
        em.RandomNumber = saveData.RandomNumber;
        em.RandomTime_1 = saveData.RandomTime_1;
        em.RandomTime_2 = saveData.RandomTime_2;
        em.RandomTime_3 = saveData.RandomTime_3;

        //ADManager
        adm.reward_dia = saveData.reward_dia;

        //CatManager
        cm.PlayPrice = saveData.PlayPrice;
        cm.PlaylerpSpeed = saveData.PlaylerpSpeed;
        cm.TouchPrice = saveData.TouchPrice;
        cm.WashPrice = saveData.WashPrice;
        cm.WashlerpSpeed = saveData.WashlerpSpeed;
        cm.HungrylerpSpeed = saveData.HungrylerpSpeed;
        cm.lerpSpeed = saveData.lerpSpeed;
        */
    }
    
    /*private void OnApplicationQuit()
    {
        Debug.Log("Save");
        Save();
    }*/
    
    // #####################################################################################################################

}
