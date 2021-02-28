using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{

    public GameObject prefabSky1;
    public GameObject prefabSky2;
    public GameObject prefabSky3;

    public int nowTime;

    LifeTime lifetime;


    void Start()
    {
        lifetime = GameObject.Find("Text_timer").GetComponent<LifeTime>();

        StartCoroutine("_ChangeBackground");

    }

    void Update()
    {
        nowTime = lifetime.timeHour;
    }

    IEnumerator _ChangeBackground()
    {
        while (true)
        {

            if (nowTime == 6) {
                if ((GameObject.Find(prefabSky3.name + "(Clone)") == true)&& (GameObject.Find(prefabSky1.name + "(Clone)") == false))
                {                    
                    Destroy((GameObject.Find(prefabSky3.name + "(Clone)")), 0.1f);
                    ChangeSprite_Background_1();
                }
            }

            else if (nowTime == 15) {
                
                if ((GameObject.Find(prefabSky1.name + "(Clone)") == true)&& (GameObject.Find(prefabSky2.name + "(Clone)") == false))
                {                    
                    Destroy((GameObject.Find(prefabSky1.name + "(Clone)")), 0.1f);
                    ChangeSprite_Background_2();
                }
            }
            else if (nowTime == 20||nowTime==0) {
                if ((GameObject.Find(prefabSky2.name + "(Clone)") == false) && (GameObject.Find(prefabSky3.name + "(Clone)") == false))
                {                    
                    ChangeSprite_Background_3();
                }
                else if ((GameObject.Find(prefabSky2.name + "(Clone)") == true) && (GameObject.Find(prefabSky3.name + "(Clone)") == false))
                {
                    Destroy((GameObject.Find(prefabSky2.name + "(Clone)")), 0.1f);
                    ChangeSprite_Background_3();
                }
            }

            yield return null;
        }

    }

    void ChangeSprite_Background_1()
    {        
        Instantiate(prefabSky1, transform.position, Quaternion.identity);
    }
    void ChangeSprite_Background_2()
    {       
        Instantiate(prefabSky2, transform.position, Quaternion.identity);
    }
    void ChangeSprite_Background_3()
    {       
        Instantiate(prefabSky3, transform.position, Quaternion.identity);
    }
    
}
