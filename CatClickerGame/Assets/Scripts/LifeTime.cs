using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeTime : MonoBehaviour
{

    public float LimitTime;
    public float ingameTime;
    public Text textTimer;
    public float timeSpeed;


    public int timeYear;
    public int timeMonth=0;
    int timeDay;
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


}
