using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;
using System.IO;

public class EventManager : MonoBehaviour
{
    GameManager gm;
    LifeTime lifetime;
    ADManager adm;


    List<string> EventList;
    int ListLength;
    public int RandomNumber;

    public GameObject Event_Popup;
    int FirstEvent_RandomTime_1;
    int FirstEvent_RandomTime_2;
    int FirstEvent_RandomTime_3;
    public int RandomTime_1;    //0~20분
    public int RandomTime_2;    //21~40분
    public int RandomTime_3;    //41~59분

    //public Button button_Yes;
    //public Button button_No;

    public Text text_Bath;
    public Text text_Hospiter;
    public Text text_ToothLose;
    public Text text_RandomEvent;


    // #####################################################################################################################
    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        lifetime = GameObject.Find("GameManager").GetComponent<LifeTime>();
        adm = GameObject.Find("ADManager").GetComponent<ADManager>();
    }

    void Start()
    {
        string path = Application.persistentDataPath + "/save.xml";
        if (System.IO.File.Exists(path))
        {
            Load();
        }

        

        EventList = new List<string>();

        FirstEvent_RandomTime_1 = Random.Range(5, 20);
        RandomTime_1 = FirstEvent_RandomTime_1;

        FirstEvent_RandomTime_2 = Random.Range(21, 40);
        RandomTime_2 = FirstEvent_RandomTime_2;

        FirstEvent_RandomTime_3 = Random.Range(41, 59);
        RandomTime_3 = FirstEvent_RandomTime_3;

        arrlist_EventText();

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
    void arrlist_EventText()
    {
        //EventList.Add("");
        EventList.Add("벌레를 잡았다?!");
        EventList.Add("수염을 주웠다!");
        EventList.Add("헤어볼을 토했다..");
        EventList.Add("화분을 부셨다!");
        EventList.Add("빈 허공을 바라봅니다.");
        EventList.Add("냉장고 위에 올라갔습니다.");
        EventList.Add("세탁기 안에서 발견되었습니다..?");
        EventList.Add("밥그릇을 엎었습니다.");
        EventList.Add("물그릇을 엎었습니다.");
        EventList.Add("휴지를 다 풀어져있습니다.");
        EventList.Add("장난감을 파괴했습니다.");
        EventList.Add("집사 명치를 밟고 지나갑니다...");
        EventList.Add("물을 찍어 먹고 있습니다...?");
        EventList.Add("침대 밑에서 \n머리끈 무더기를 발견했습니다.");
        EventList.Add("집사를 핥다가 갑자기 때렸습니다..?!");
        EventList.Add("노트북의 전원을 꺼버렸습니다.");



        ListLength = EventList.Count;
        RandomNumber = Random.Range(0, ListLength);

    }

    void _EventManagement()
    {
        if (Event_Popup.activeSelf == false)
        {

            if (lifetime.dt.ToString("MMddHH") == "040513")
            {
                Event_Bath();
            }
            if (lifetime.dt.ToString("MMddHH") == "011509")
            {
                Event_Hospiter();
            }
            if (lifetime.dt.ToString("MMddHH") == "060119")
            {
                Event_ToothLose();
            }
            if (lifetime.dt.ToString("HH") == RandomTime_1.ToString())
            {
                Event_RandomEvent_1();
            }
            if (lifetime.dt.ToString("HH") == RandomTime_2.ToString())
            {
                Event_RandomEvent_2();
            }
            if (lifetime.dt.ToString("HH") == RandomTime_3.ToString())
            {
                Event_RandomEvent_3();
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

        text_RandomEvent.text = EventList[RandomNumber - 1];
        Event_Popup.SetActive(true);

        RandomTime_1 = Random.Range(0, 20);
        RandomNumber = Random.Range(0, ListLength);

    }
    void Event_RandomEvent_2()
    {
        text_RandomEvent.text = EventList[RandomNumber - 1];
        Event_Popup.SetActive(true);

        RandomTime_2 = Random.Range(21, 40);
        RandomNumber = Random.Range(0, ListLength);

    }
    void Event_RandomEvent_3()
    {
        text_RandomEvent.text = EventList[RandomNumber - 1];
        Event_Popup.SetActive(true);

        RandomTime_3 = Random.Range(41, 59);
        RandomNumber = Random.Range(0, ListLength);

    }

    public void showad()
    {
        adm.Show_RewardVideo();
        Event_Popup.SetActive(false);
    }

    
    // #####################################################################################################################
    /*
    void Save()
    {
        SaveData saveData = new SaveData();

        saveData.RandomNumber = RandomNumber;
        saveData.RandomTime_1 = RandomTime_1;    
        saveData.RandomTime_2 = RandomTime_2;    
        saveData.RandomTime_3 = RandomTime_3;    

    string path = Application.persistentDataPath + "/save.xml";
        XmlManager.XmlSave<SaveData>(saveData, path);
    }
    */
    void Load()
    {

        SaveData saveData = new SaveData();
        string path = Application.persistentDataPath + "/save.xml";
        saveData = XmlManager.XmlLoad<SaveData>(path);

        RandomNumber = saveData.RandomNumber;
        RandomTime_1 = saveData.RandomTime_1;
        RandomTime_2 = saveData.RandomTime_2;
        RandomTime_3 = saveData.RandomTime_3;

    }

    
    // #####################################################################################################################
}
