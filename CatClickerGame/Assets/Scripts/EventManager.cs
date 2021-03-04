using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class EventManager : MonoBehaviour
{
    

    GameManager gm;
    LifeTime lifetime;
    ADManager adm;

    public GameObject Event_Popup;
    int FirstEvent_RandomTime_1;
    int FirstEvent_RandomTime_2;
    public int RandomTime_1;    //1일~15일
    public int RandomTime_2;    //16일~30    //너무 텀이 긴것 같으면 더 추가하기

    public Button button_Yes;
    public Button button_No;

    public Text text_Bath;
    public Text text_Hospiter;
    public Text text_ToothLose;
    public Text text_RandomEvent;


    // #####################################################################################################################

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        lifetime = GameObject.Find("Text_timer").GetComponent<LifeTime>();
        adm = GameObject.Find("ADManager").GetComponent<ADManager>();

        FirstEvent_RandomTime_1 = Random.Range(5, 15);
        RandomTime_1 = FirstEvent_RandomTime_1;

        FirstEvent_RandomTime_2 = Random.Range(16, 30);
        RandomTime_2 = FirstEvent_RandomTime_2;

    }

    void Update()
    {
        _EventManagement();
    }

    /* #####################################################################################################################

    ㅁ 패널 생성해서 패널 띄우기
        <gameobject>.SetActive(true);
        [예/아니오]버튼 만들어서 광고 재생


    ㅁ 첫 목욕시키기 4개월 +1달마다?2달마다 반복
        또는 깨끗함 게이지가 다 차면 이벤트 발생시키기(게이지 감소)    

    ㅁ 젖니빠짐 6개월
        광고보상, 창틀에 병모양 추가

    ㅁ 예방접종 50일
        중성화 Neutralization
        종합검진 성묘되고 6개월마다

    ㅁ 랜덤일로 뽑아서 참새를 나에게 준다거나, 벌레를 잡는다거나 하는 이벤트 넣기
        이벤트 발생 시 광고 재생-보상


    ##################################################################################################################### */



    void _EventManagement()
    {
        if (Event_Popup.activeSelf == false)
        {
            if (lifetime.timeMonth == 4&&lifetime.timeDay == 5 && lifetime.timeHour == 13)      //4월 5일 13시
            {
                Event_Bath();
            }

            if (lifetime.timeMonth == 1 && lifetime.timeDay == 15 && lifetime.timeHour == 9)    //1월 15일 9시
            {
                Event_Hospiter();
            }

            if (lifetime.timeMonth == 6 && lifetime.timeDay == 1&&lifetime.timeHour == 19)      //6월 1일 19시
            {
                Event_ToothLose();
            }

            if (lifetime.timeDay == RandomTime_1)                                                 //랜덤일 0시
            {
                Event_RandomEvent_1();
            }

            if (lifetime.timeDay == RandomTime_2)                                                 //랜덤일 0시
            {
                Event_RandomEvent_2();
            }
        }
        
            
        

    }

    void Event_Bath()
    {
        text_Bath.text = "목욕 하는날!";
        Event_Popup.SetActive(true);
    }

    void Event_Hospiter()
    {
        text_Hospiter.text = "첫 건강검전 받는날!";
        Event_Popup.SetActive(true);
    }

    void Event_ToothLose()
    {
        text_ToothLose.text = "빠진 젖니를 발견했습니다";
        Event_Popup.SetActive(true);
    }

    void Event_RandomEvent_1()
    {
        text_RandomEvent.text = "랜덤이벤트1 발생!";
        Event_Popup.SetActive(true);

        RandomTime_1 = Random.Range(1, 15);

    }
    void Event_RandomEvent_2()
    {
        text_RandomEvent.text = "랜덤이벤트2 발생!";
        Event_Popup.SetActive(true);

        RandomTime_2 = Random.Range(16, 30);

    }





    public void showad()
    {
        adm.Show_RewardVideo();
        Event_Popup.SetActive(false);
    }

}
