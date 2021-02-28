using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToyManager : MonoBehaviour
{
    
    public long ToyCreatePrice;
    public long ToyIncreaseAmount;
    public long ToyIncreaseLevel;
    public long ToyIncreasePrice;
    public string ToyName;

    public Text textToyIncreasePrice;
    public Text textToyUpgradePrice;
    public Button ToyIncreaseButton;

    public GameObject prefabToy;


    GameManager gm;

    public Vector2 point;


    // #####################################################################################################################

    void Start()
    {       
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

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
        if (GameObject.Find(prefabToy.name + "(Clone)") == false)
        {
            if (gm.heart >= ToyCreatePrice)
            {
                gm.heart -= ToyCreatePrice;
                Instantiate(prefabToy, point, Quaternion.identity);
            }
            StartCoroutine(autoClick());
        }       

    }


    public void ToyIncreaseLevelUpgrade()
    {
        if (GameObject.Find(prefabToy.name + "(Clone)") == true)
        {
            if (gm.heart >= ToyIncreasePrice)
            {
                gm.heart -= ToyIncreasePrice;
                ToyIncreaseLevel += 1;
                ToyIncreaseAmount += ToyIncreaseLevel * 2;
                ToyIncreasePrice += ToyIncreaseLevel * 10;

            }

        }
    }

    void ToyIncreaseUpdatePanelText()
    {
        textToyIncreasePrice.text = ToyName+"Lv." + ToyIncreaseLevel + "\n" +"5초당 " + ToyIncreaseAmount + "개 획득";

    }

    void ToyIncreaseUpdatePriceText()
    {
        if (GameObject.Find(prefabToy.name + "(Clone)") == false)
        {
            textToyUpgradePrice.text = "설치<" + ToyIncreasePrice.ToString() + ">";
        }

        if (GameObject.Find(prefabToy.name + "(Clone)") == true)
        {
            textToyUpgradePrice.text = ToyIncreasePrice.ToString();
        }
    }



    void ButtonActiveCheck()
    {
        if (gm.heart >= ToyCreatePrice)
        {
            ToyIncreaseButton.interactable = true;
        }
        else
        {
            ToyIncreaseButton.interactable = false;
        }


        if (gm.heart >= ToyIncreasePrice)
        {
            ToyIncreaseButton.interactable = true;
        }
        else
        {
            ToyIncreaseButton.interactable = false;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(point, 0.2f);
    }


}