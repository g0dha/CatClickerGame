using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class LifeTime : MonoBehaviour
{
    /*
     **** 변경사항 ****
     ㅁ 인게임 시작 적용(8초에 1시간) -> 현실시간 적용
     ㅁ 시간을 받아와 얼만큼 지났는지 적용해야 함(수식)
     ㅁ 게임이 꺼져 있을 때에도 스테이터스에 적용할 것        
     
     */

    public int timeYear;
    public int timeMonth;
    public int timeDay;
    public int timeHour;

    public DateTime dt = DateTime.Now;
    public Text text_Date;
    public Text text_PlayTime;

    //string lastTime = PlayerPrefs.GetString("SaveLastTime");
    //DateTime lastDateTime;
    //TimeSpan conpareTime;



    String LastTime;

    void Start()
    {
        timeYear = dt.Year;
        timeMonth = dt.Month;
        timeDay = dt.Day;
        timeHour = dt.Hour;

        //GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        //PlayerPrefs.SetString("SaveLastTime", System.DateTime.Now.ToString());
        //lastDateTime = DateTime.Parse(lastTime);
        //conpareTime = dt - lastDateTime;

    }

    void Update()
    {
        text_Date.text = dt.ToString("yyyy년 MM월 dd일\nHH시 mm분");

    }

    void _PlayTime()
    {

    }





    /*
    public float LimitTime;
    public float ingameTime;
    public Text textTimer;
    public float timeSpeed;


    public int timeYear;
    public int timeMonth=0;
    public int timeDay;
    public int timeHour;


    void Start()
    {
        LimitTime = 0f;
        timeDay = 1;
    }

    void Update()
    {
        addLifeTime();
        CalTime();
        ShowInfo();

    }



    void addLifeTime()
    {
        LimitTime += Time.deltaTime;
    }

    void ShowInfo()
    {
        textTimer.text = timeYear + "년 " + timeMonth + "월 " + timeDay + "일 " + timeHour + "시";

    }

    void CalTime()
    {
        ingameTime = LimitTime / timeSpeed;

        timeHour = (int)ingameTime % 24;
        timeDay = (int)ingameTime / 24;

        if (timeDay > 30)
        {
            timeMonth = timeDay / 30;
            timeDay = timeDay % 30;
        }

        if (timeMonth > 12)
        {
            timeYear = timeMonth / 12;
            timeMonth = timeMonth % 12;
        }
    }
    */

}
