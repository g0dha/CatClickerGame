using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro_animation : MonoBehaviour
{
    public float StopTime;

    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public Sprite sprites_2;

    public GameObject speech;

    public GameObject PanelName;
    public InputField textName;
    public string text_CatName;

    public GameObject PanelGender;
    public int Gender_value;

    public GameObject PanelInfo;
    public Text textCatInfo;


    void Start()
    {
        //speech.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[0];

        StartCoroutine("_changeLight");
        
    }

    void Update()
    {
        StopTime += Time.deltaTime;
        PopSpeech();
        //PopPanelName();
        PopInfo();

        text_CatName = textName.text;
       
    }

    IEnumerator _changeLight()
    {
        while (StopTime < 3)
        {
            if (spriteRenderer.sprite == sprites[0])
            {
                spriteRenderer.sprite = sprites[1];
                yield return new WaitForSeconds(0.7f);
            }
            else if (spriteRenderer.sprite == sprites[1])
            {
                spriteRenderer.sprite = sprites[0];
                yield return new WaitForSeconds(0.3f);
            }
            if (StopTime >= 3)
            {
                spriteRenderer.sprite = sprites[1];
                yield return null;
            }
        }                
    }

    void PopSpeech()
    {
        if (StopTime >= 4f)
        {
            speech.SetActive(true);
        }
        if (StopTime >= 6f)
        {            
            speech.SetActive(false);
            spriteRenderer.sprite = sprites_2;
        }
        if (StopTime >= 8.5f)
        {
            PanelName.SetActive(true);
            //text_CatName = textName;
        }      
    }
    

    public void StroyGender()
    {
        PanelGender.SetActive(true);
    }

    public void _button_male()
    {
        Gender_value = 1;
        PanelInfo.SetActive(true);
    }

    public void _button_female()
    {
        Gender_value = 2;
        PanelInfo.SetActive(true);
    }

    void PopInfo()
    {        
        if (Gender_value == 1)
        {
            textCatInfo.text = text_CatName+" / 수컷";
        }
        else if (Gender_value == 2)
        {
            textCatInfo.text = text_CatName+" / 암컷";
        }
    }

    public void _button_Yes()
    {
        SceneManager.LoadScene("1_Playing");
    }

    public void _button_No()
    {
        SceneManager.LoadScene("0.1_intro");
    }
}
