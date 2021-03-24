﻿using System;
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
   

    void Start()
    {
        timeYear = dt.Year;
        timeMonth = dt.Month;
        timeDay = dt.Day;
        timeHour = dt.Hour;
    }

    void Update()
    {
        DateTime dt = DateTime.Now;
        text_Date.text = dt.ToString("yyyy년 MM월 dd일\nHH시 mm분");
    }
}
