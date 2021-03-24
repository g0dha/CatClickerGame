# CatClickerGame
1. 프로젝트 명 : CatClickerGame

2. 기간 : 2021.02.21~

3. 카테고리 : 클리커게임, 육성, 도트픽셀

4. 재화 : 하트, 다이아

5. 시간 ➡ 실제 시간 받아서 해보기.
   
   1. **낮(6시~15시)/저녁(16시~19시)/밤(20시~6시)**
   2. ~~20초당 1시간(1일=8분/1달=2시간/1년=48시간) 조정가능~~ ➡ **현실시간반영으로 변경**
   
6. 기능
   1. **하트모으기 : 패널을 제외한 화면을 터치할 시 하트 획득**
      1. **클릭시 1하트 획득 ➡ 클릭시 더 많은 하트 획득가능 (업그레이드)**
      2. **오토 획득 ➡ 캣타워 등 설치시 오토 획득 (업그레이드 가능)**
   2. 고양이 성장 : **시간누적** + 조건? 달성시 성장
      1. 아기 : 시작 캐릭터. 
      2. 어린이 : 1단계 성장. 6개월 이상(누적 플레이타임 12시간)
      3. 성묘 : 2단계 성장(성장 끝). 12개월 이상(누적 플레이타임 48시간...)
   3. **광고보기**
      1. 높은 재화 획득 가능, 특정 값 사이에서 랜덤 or 특정 값
      2. **랜덤 이벤트 발생 시 yes를 보면 광고 재생, 리워드 지급**
   4. 훈련
      1. 앉아
      2. 기다려
      3. 손
      4. 하이파이브
   
7. 씬

   1. 시작화면
   2. 인트로영상
   3. 인게임화면

8. **스테이터스**(점점 감소)

   1. **배고픔 : 밥 주면 회복**
   2. **깨끗함 : 냥빨**
   3. **재밌음 : 놀아주기, 쓰다듬기**

9. 추가할 내용

   - [x] 값 지정
   - [x] 이름, 성별 지어주기 + 인트로(주워오기)
   - [ ] 움직이는 모션 추가
   - [ ] 리워드 재화로 할 수 있는 것
   - [ ] 성장조건
   - [x] 스크롤바

   

#### 고양이 성장 및 이벤트 정리

|                    | **아기고양이**       | **어린이고양이**      | **어른고양이**          |
| ------------------ | -------------------- | --------------------- | ----------------------- |
| **누적플레이타임** | **0 ~6개월**         | **6~12개월**          | **12개월~**             |
| 특정조건           | 없음                 | 미정                  | 미정                    |
| 이벤트             | **첫 목욕(4개월)**   | 중성화선택(7개월이상) | **종합검진(6개월마다)** |
|                    | **젖니빠짐(6개월)**  |                       |                         |
|                    | **예방접종(50일경)** |                       |                         |

#### 업그레이드

|           | 증가폭   | 업그레이드 가격 |
| --------- | -------- | --------------- |
| 직접 클릭 | 레벨 * 2 | 레벨 * 10       |
| 오토 클릭 | 레벨 * 2 | 레벨 * 10       |

####  

#### 오토클릭 종류 - 5초에 1번씩 획득

| 종류             | 금액  | 위치          | 기타                  |
| ---------------- | ----- | ------------- | --------------------- |
| **스크래쳐**     | 100   | **가운데**    |                       |
| **미캉상자**     | 500   | **왼쪽**      |                       |
| **낚싯대장난감** | 1500  | **왼쪽 아래** | **[놀아주기] 활성화** |
| **캣타워**       | 10000 | **오른쪽**    |                       |



#### 스크립트 정리

|               | 스크립트         | 변수                                                         | 함수                                                         | 게임오브젝트                                                 | UI                                                           | 기타                         |
| ------------- | ---------------- | ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ | ---------------------------- |
| 배경          |                  |                                                              |                                                              | Background<br />Background_room<br />Image_dish              | Panel_Top(PT) <br />Panel_Button(PB)                         |                              |
| 배경변화      | ChangeBackgorund | private SpriteRenderer spriteRenderer;<br/>    public Sprite[] sprites;<br/><br/>    public int nowTime;<br/>    <br/>    LifeTime lifetime; | Start() <br />Update() <br />IEnumerator _ChangeBackground() | Background                                                   |                                                              | 시간에 따라 배경변화         |
| 캐릭터        | HeartMove        | public Vector2 point;                                        | Start() <br />Update()                                       |                                                              |                                                              |                              |
| 성장          | ChangeCat        | private SpriteRenderer spriteRenderer;<br/>    public Sprite[] sprites;<br/><br/>    LifeTime lifetime; | Start()<br />IEnumerator _ChangeCat()                        | Cat                                                          |                                                              |                              |
| GM            | GameManager      | public long heart;<br />public long heartIncreaseAmount;<br />public Text textHeart; <br />public GameObject prefabHeart; | Awake()<br />Start() <br />Update() <br />ShowInfo() <br />HeartIncrease() | GameManager                                                  |                                                              |                              |
| 시간계산      | LifeTime         | public int timeYear;<br/>    public int timeMonth;<br/>    public int timeDay;<br/>    public int timeHour;<br/><br/>    public DateTime dt;<br/>    public Text text_Date;<br/>    public Text text_PlayTime;<br/><br/>    DateTime startDate;<br/>    DateTime now;<br/>    public double PlayTime;<br/>    string StartDate;<br/><br/>    String LastTime; | Start() <br />Update() <br />_PlayTime()                     |                                                              | Text_timer(PT) <br />Image_itmer_space(PT)                   |                              |
| 먹이주기      | GameManager      | public long foodPrice;<br />public Button foodButton;<br />public GameObject prefabFoodDish;<br />public int food_lifeTime; | ButtonActiveCheck() <br />feedPrice()<br />ChangeSprite_Food() |                                                              | Button_food(PB)                                              | 10초뒤에 먹이(이미지) 사라짐 |
| 업그레이드    | GameManager      | public long heart;<br />public long heartIncreaseAmount;<br />public long heartIncreaseLevel;<br />public long heartIncreasePrice;<br />public Text textHeart;public Text textHeartIncreasePrice;<br />public Text textHeartUpgradePrice;<br />public Button HeartIncreaseButton; | HeartIncrease() <br />HeartIncreaseLevelUpgrade()  <br />HeartIncreaseUpdatePanelText() <br />HeartIncreaseUpdatePriceText() <br />ButtonActiveCheck() |                                                              | Button_HeartIncrease(PB) <br />Panel_HeartIncreasePriceUpgrade |                              |
| 장난감        | ToyManager       | public long ToyCreatePrice;<br/>    public long ToyIncreaseAmount;<br/>    public long ToyIncreaseLevel;<br/>    public long ToyIncreasePrice;<br/>    public string ToyName;<br/><br/>    public Text textToyIncreasePrice;<br/>    public Text textToyUpgradePrice;<br/>    public Button ToyIncreaseButton;<br/><br/>    public GameObject prefabToy;<br/><br/><br/>    GameManager gm;<br/><br/>    public Vector2 point; | Awake()<br />Start()<br />Update()<br />IEnumerator autoClick()<br />ToyCreateButton()<br />public void ToyIncreaseLevelUpgrade()<br />ToyIncreaseUpdatePanelText()<br /> | ToyManager_Box<br />ToyManager_Scratcher<br />ToyManager_CatTower<br />ToyManager_Toy | Panel_Toy<br />Button_Toy(PB)                                |                              |
| 고양이관리    | CatManager       | ToyManager toy;<br/>    GameManager gm;<br/><br/>    public int PlayPrice;<br/>    public Button PlayButton;<br/>    public Text textPlay;<br/>    public Image imagePlay;<br/>    public float PlaylerpSpeed;<br/>public int TouchPrice;<br/>    public Button TouchButton;<br/>    public Text textTouch;<br/>    public int WashPrice;<br/>    public Button WashButton;<br/>    public Text textWash;<br/>    public Image imageWash;<br/>    public float WashlerpSpeed;<br/><br/>    public Button HungryButton;<br/>    public Image imageHungry;<br/>    public float HungrylerpSpeed;<br/><br/>    public float lerpSpeed; | Awake()<br />Start()<br />Update()<br />ButtonActiveCheck()<br />_PlayBtton()<br />_TouchBtton()<br />_WashBtton()<br />_HungryBtton()<br />FunnyStatus()<br />WashStatus()<br />HungryStatus() | CatManager                                                   | Panel_Management<br />Panel_Status<br />Button_Management(PB)<br />Button_Food(PB) |                              |
| 광고넣기      | ADManager        |                                                              | Awake()<br />Start()<br />AD_Initialize()<br />AD_Request<br />Show_RewardVideo<br /> | ADManager                                                    |                                                              | 리워드 광고                  |
| 광고 불러오기 | GameManager      | public Button adButton;<br/>    public float leftTime;<br/>    public float backup_leftTime;<br/>    public Text textleftTime;<br/>    ADManager adm; | Start()<br />ButtonActiveCheck()<br />showad()<br />IEnumerator rewardVideo()<br />IEnumerator decreaseTime() |                                                              | Button_Ad(PB)                                                |                              |
| 이벤트처리    | EvnetManager     | GameManager gm;<br/>    LifeTime lifetime;<br/>    ADManager adm;<br/><br/>    List<string> EventList;<br/>    int ListLength;<br/>    public int RandomNumber;<br/><br/>    public GameObject Event_Popup;<br/>    int FirstEvent_RandomTime_1;<br/>    int FirstEvent_RandomTime_2;<br/>    int FirstEvent_RandomTime_3;<br/>    public int RandomTime_1;    //0~20분<br/>    public int RandomTime_2;    //21~40분<br/>    public int RandomTime_3;    //41~59분<br/><br/>    public Button button_Yes;<br/>    public Button button_No;<br/><br/>    public Text text_Bath;<br/>    public Text text_Hospiter;<br/>    public Text text_ToothLose;<br/>    public Text text_RandomEvent; | Awake()<br />Start()<br />Update()<br />arrlist_EventText()<br />_EventManagement()<br />Event_Bath()<br />Event_Hospiter()<br />Event_ToothLose()<br />Event_RandomEvent_1()<br />Event_RandomEvent_2<br />Event_RandomEvent_3<br />showad() | EventManager                                                 | Panel_Event                                                  | 이벤트내용 추가하기          |
| 화면전환      | GameManager      | public GameObject Panel_Exit;                                | Update()<br />ExitGame()<br />Exit_Yes()<br />Exit_No()      | Title<br />Background                                        | Button_Start<br />Image_catface                              | Scene0                       |
|               | StartScene       | public Vector2 point;<br/>    public Vector2 EndPosition;<br/><br/>    public float DownSpeed;<br/>    public float alpha;<br/><br/>    public GameObject button_Start;<br/>    public GameObject CatFace; | Start()<br />Update()<br />IEnumerator MoveTitle()<br />Pop_Image()<br />Pop_Button()<br />ChangePlayGameScene() |                                                              | Panel_Exit                                                   | Scene1                       |
| 인트로        | Intro_animation  | public float StopTime;<br/><br/>    private SpriteRenderer spriteRenderer;<br/>    public Sprite[] sprites;<br/>    public Sprite sprites_2;<br/><br/>    public GameObject speech;<br/><br/>    public GameObject PanelName;<br/>    public InputField textName;<br/>    public static string text_CatName;<br/><br/>    public GameObject PanelGender;<br/>    //public Button button_male;<br/>    //public Button button_female;<br/>    public int Gender_value;<br/><br/>    public GameObject PanelInfo;<br/>    public Text textCatInfo; | Start()<br />Update()<br />IEnumerator Genderbutton_male()<br />_button_female()<br />PopInfo()<br />_button_Yes()<br />_button_No()<br /> | Image_speech<br />IntroManager                               | Panel_Name<br />Gender<br />Panel_Info                       |                              |



#### 조정해야 할 변수 값 정리

| 게임오브젝트             | 변수 **명**         | 변수 값 | 설명                                          |
| ------------------------ | ------------------- | ------- | --------------------------------------------- |
| **GameManager**          | HeartIncreaseAmount | 수식    | heartIncreaseLevel * 3.3                      |
|                          | HeartIncreasePrice  | 수식    | Mathf.Pow(3,heartIncreaseLevel)*5             |
|                          | FoodPirce           | 수식    | 100*HeartIncreaseLevel                        |
|                          | Food_lifeTime       | 30      | food프리팹이 사라지는데 걸리는 시간           |
| **CatManager**           | PlayPrice           | 100     |                                               |
|                          | TouchPirce          | 100     |                                               |
|                          | WashPirce           | 300     |                                               |
|                          | PlaylerpSpeed       | 수식    | Time.deltaTime/lerpSpeed                      |
|                          | WashlerpSpeed       | 수식    | Time.deltaTime/lerpSpeed*0.01                 |
|                          | HungrylerpSpeed     | 수식    | Time.deltaTime/lerpSpeed*0.6                  |
|                          | LerpSpeed           | 500     | bar 증감 속도 조절                            |
| **ToyManager_Toy**       | ToyCreatePrice      | 100     |                                               |
|                          | alpha               | 3       | alpha : 가격 차이를 두기 위한 값              |
|                          | ToyIncreaseAmount   | 수식    | ToyIncreaseLevel* 10 *alpha                   |
|                          | ToyIncreasePirce    | 수식    | Mathf.Pow(2,ToyIncreaseLevel)* *alpha* *alpha |
| **ToyManager_Scratcher** | ToyCreatePrice      | 500     |                                               |
|                          | alpha               | 9       |                                               |
|                          | ToyIncreaseAmount   | 수식    | ToyIncreaseLevel* 10 *alpha                   |
|                          | ToyIncreasePirce    | 수식    | Mathf.Pow(2,ToyIncreaseLevel)* *alpha* *alpha |
| **ToyManager_Box**       | ToyCreatePrice      | 1500    |                                               |
|                          | alpha               | 21      |                                               |
|                          | ToyIncreaseAmount   | 수식    | ToyIncreaseLevel* 10 *alpha                   |
|                          | ToyIncreasePirce    | 수식    | Mathf.Pow(2,ToyIncreaseLevel)* *alpha* *alpha |
| **ToyManager_CatTower**  | ToyCreatePrice      | 10000   |                                               |
|                          | alpha               | 30      |                                               |
|                          | ToyIncreaseAmount   | 수식    | ToyIncreaseLevel* 10 *alpha                   |
|                          | ToyIncreasePirce    | 수식    | Mathf.Pow(2,ToyIncreaseLevel)* *alpha* *alpha |
| **(PT)Text_timer**       | TimeSpeed           | 8       | 몇초당 1시간(인게임시간)으로 할 지            |
| **ADManager**            | backup_leftTime     | 300     | 다음광고까지 걸리는 시간(초)                  |

