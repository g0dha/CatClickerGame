using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyCreate
{
    public long ToyIncreaseAmount;
    public long ToyIncreaseLevel;
    public long ToyIncreasePrice;
    public Text textToy;
    public Text textToyIncreasePrice;
    public Text textToyUpgradePrice;
    public Button ToyIncreaseButton;

    AutoClick ac;

    // Start is called before the first frame update
    void Start()
    {
        ac = GameObject.Find("");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToyIncreaseLevelUpgrade()
    {
        if (heart >= heartIncreasePrice)
        {

            heart -= heartIncreasePrice;
            heartIncreaseLevel += 1;
            heartIncreaseAmount += heartIncreaseLevel * 2;
            heartIncreasePrice += heartIncreaseLevel * 10;


        }
    }

    void ToyIncreaseUpdatePanelText()
    {
        textHeartIncreasePrice.text = "Lv." + heartIncreaseLevel + "\n" + "클릭시 " + heartIncreaseAmount + "개 획득";

    }

    void ToyIncreaseUpdatePriceText()
    {
        textHeartUpgradePrice.text = heartIncreasePrice.ToString();
    }



    void ButtonActiveCheck()
    {      

        if (heart >= ToyIncreasePrice)
        {
            ToyIncreaseButton.interactable = true;
        }
        else
        {
            ToyIncreaseButton.interactable = false;
        }
    }
}
