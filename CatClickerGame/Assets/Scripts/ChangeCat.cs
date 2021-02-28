using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCat : MonoBehaviour
{

    public GameObject prefabCat1;
    public GameObject prefabCat2;
    public GameObject prefabCat3;

    LifeTime lifetime;


    void Start()
    {
        lifetime = GameObject.Find("Text_timer").GetComponent<LifeTime>();        
    }

    void Update()
    {
        
        _ChangeCat();
    }

    void _ChangeCat()
    {
        if (lifetime.timeYear == 0&&lifetime.timeMonth == 0)
        {
            if ((GameObject.Find(prefabCat1.name + "(Clone)") == false))
            {
                SpriteRenderer sr = GetComponent<SpriteRenderer>();
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0);
                ChangeSprite_Cat_1();
            }
        }
        else if (lifetime.timeYear == 0&&lifetime.timeMonth == 1)
        {

            if ((GameObject.Find(prefabCat1.name + "(Clone)") == true)&& (GameObject.Find(prefabCat2.name+"(Clone)") == false))
            {   
                ChangeSprite_Cat_2();
                Destroy((GameObject.Find(prefabCat1.name + "(Clone)")), 0f);
                
            }
        }
        else if (lifetime.timeYear == 1)
        {
            if ((GameObject.Find(prefabCat2.name + "(Clone)") == true)&& (GameObject.Find(prefabCat3.name+ "(Clone)") == true))
            {
                Destroy((GameObject.Find(prefabCat2.name + "(Clone)")), 0f);
                ChangeSprite_Cat_3();
            }
            
        }
    }
    void ChangeSprite_Cat_1()
    {
        Instantiate(prefabCat1, transform.position, Quaternion.identity);
    }
    void ChangeSprite_Cat_2()
    {       
        Instantiate(prefabCat2, transform.position, Quaternion.identity);
    }
    void ChangeSprite_Cat_3()
    {       
        Instantiate(prefabCat3, transform.position, Quaternion.identity);
    }
    
}
