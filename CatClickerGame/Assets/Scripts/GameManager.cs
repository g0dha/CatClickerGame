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

    public GameObject prefabFoodDish;
    public int food_lifeTime;

    public Button adButton;
    public float leftTime;
    public float backup_leftTime;
    public Text textleftTime;

    public GameObject Panel_Exit;

    ADManager adm;




    // #####################################################################################################################

    void Start()
    {
        adm = GameObject.Find("ADManager").GetComponent<ADManager>();
        leftTime = 0f;
        
    }


    void Update()
    {        
        ShowInfo();

        HeartIncrease(); 
        HeartIncreaseUpdatePanelText();
        HeartIncreaseUpdatePriceText();
        
        ButtonActiveCheck();

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
            heartIncreaseAmount += heartIncreaseLevel * 2;
            heartIncreasePrice += heartIncreaseLevel * 10;
        }
    }

    void HeartIncreaseUpdatePanelText()
    {
        textHeartIncreasePrice.text = "Lv." + heartIncreaseLevel+"\n"+"클릭시 " + heartIncreaseAmount+ "개 획득";  
        
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
        
        if (leftTime >0f)
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
            foodPrice = heartIncreaseLevel * 10;
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
        while (leftTime >0)
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
        Application.Quit();
    }

    public void Exit_No()
    {
        Time.timeScale = 1f;
        Panel_Exit.SetActive(false);
    }

    // #####################################################################################################################



}
