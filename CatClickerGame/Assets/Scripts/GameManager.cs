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
      
    



    // #####################################################################################################################

    void Start()
    {
        
    }


    void Update()
    {
        ShowInfo();

        HeartIncrease(); 
        HeartIncreaseUpdatePanelText();
        HeartIncreaseUpdatePriceText();
        
        ButtonActiveCheck();

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
            if (EventSystem.current.IsPointerOverGameObject() == false)
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



    void ButtonActiveCheck()
    {
        if (heart >= foodPrice)
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
    }


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

    


}
