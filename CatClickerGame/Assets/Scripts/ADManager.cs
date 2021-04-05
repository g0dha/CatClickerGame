using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using GoogleMobileAds.Api;
using System.IO;



public class ADManager : MonoBehaviour
{
    RewardBasedVideoAd m_AD_RewardVideo;
    
    
    // AdMob 에서 발급된 AppID
    string m_App_Id = "ca-app-pub-3379886564047452~7923375790";
    // AdMob 에서 각 광고단위로 발급된 UnitID 중 리워드광고 ID
    string m_Ad_UnitId_Reward = "ca-app-pub-3379886564047452/5206353743";
    //string m_Ad_UnitId_Reward = "ca-app-pub-3940256099942544/5224354917";   //TEST ID

    public long reward_dia;
    public Text text_reward_dia;
    public long RandomValue_dia;
    public long RandomValue_heart;
    GameManager gm;


    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        string path = Application.persistentDataPath + "/save.xml";
        if (System.IO.File.Exists(path))
        {
            Load();
        }
                
        text_reward_dia.text = reward_dia.ToString();
        

        AD_Initialize();


    }


    void AD_Initialize()
    {

        // 앱ID 로 초기화
        MobileAds.Initialize(m_App_Id);

        // 리워드광고를 받을 수 있게 준비
        m_AD_RewardVideo = RewardBasedVideoAd.Instance;

        m_AD_RewardVideo.OnAdLoaded += this.H_RewardVideoLoad;
        m_AD_RewardVideo.OnAdFailedToLoad += this.H_RewardVideoFailedToLoad;
        m_AD_RewardVideo.OnAdStarted += this.H_RewardVideoStart;
        m_AD_RewardVideo.OnAdOpening += this.H_RewardVideoOpen;
        m_AD_RewardVideo.OnAdClosed += this.H_RewardVideoClose;
        m_AD_RewardVideo.OnAdRewarded += this.H_RewardVideoReward;
        m_AD_RewardVideo.OnAdLeavingApplication += this.H_RewardVideoLeftApplication;

        AD_Request();
    }

    void AD_Request()
    {

        // 광고 요청 조건 자료구조 생성
        AdRequest t_Request = new AdRequest.Builder().AddTestDevice("6969CEE4E18C4D85A3900F9E3D0B2DE2").Build();
        //AdRequest t_Request = new AdRequest.Builder().Build();
        // 리워드광고에 대한 광고 정보 요청
        m_AD_RewardVideo.LoadAd(t_Request, m_Ad_UnitId_Reward);
    }

    public void Show_RewardVideo()
    {

        
        if (m_AD_RewardVideo.IsLoaded())
        {
            // 준비된 광고 표시(노출)
            m_AD_RewardVideo.Show();
        }
    }

    

    // 광고 로드가 완료되면 실행될 함수
    public void H_RewardVideoLoad(object sender, EventArgs args)
    {
    }
    // 광고 로드가 실패하면 실행될 함수
    public void H_RewardVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
    }

    // 광고가 시작되면 실행될 함수
    public void H_RewardVideoStart(object sender, EventArgs args)
    {
    }

    // 광고가 오픈(노출)되면 실행될 함수
    public void H_RewardVideoOpen(object sender, EventArgs args)
    {
        
    }

    // 광고가 오픈 후 닫히면 실행될 함수
    public void H_RewardVideoClose(object sender, EventArgs args)
    {
        AD_Request();
    }

    // 리워드 광고 조건을 만족한 경우 실행되는 함수
    public void H_RewardVideoReward(object sender, Reward args)
    {
        string type = args.Type;        //리워드 상품
        double amount = args.Amount;    //리워드 수량

        RandomValue_dia = Random.Range(1, 5);
        reward_dia += RandomValue_dia;
        text_reward_dia.text = reward_dia.ToString();

        RandomValue_heart = Random.Range(1000, 30000);
        gm.heart += Random.Range(1, 5);

    }

    // 광고 실행 중에 어플리케이션이 강제로 종료되는 경우 실행되는 함수
    public void H_RewardVideoLeftApplication(object sender, EventArgs args)
    {
    }
    
    // #####################################################################################################################

    void Load()
    {

        SaveData saveData = new SaveData();
        string path = Application.persistentDataPath + "/save.xml";
        saveData = XmlManager.XmlLoad<SaveData>(path);

        reward_dia = saveData.reward_dia;

    }

    // #####################################################################################################################

}