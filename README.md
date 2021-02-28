# CatClickerGame
1. 프로젝트 명 : CatClickerGame
2. 기간 : 2021.02.21~
3. 카테고리 : 클리커게임, 육성, 도트픽셀
4. 재화 : 하트
5. 시간
   1. 낮(6시~15시)/저녁(15시~20시)/밤(20시~6시)
   2. 20초당 1시간(1일=8분/1달=2시간/1년=48시간) **조정가능**
6. 기능
   1. 하트모으기 : 패널을 제외한 화면을 터치할 시 하트 획득
      1. 클릭시 1하트 획득 ➡ 클릭시 더 많은 하트 획득가능 (업그레이드)
      2. 오토 획득 ➡ 캣타워 등 설치시 오토 획득 (업그레이드 가능)
   2. 고양이 성장 : 시간누적 + 조건 달성시 성장
      1. 아기 : 시작 캐릭터. 
      2. 어린이 : 1단계 성장. 6개월 이상(누적 플레이타임 12시간)
      3. 성묘 : 2단계 성장(성장 끝). 12개월 이상(누적 플레이타임 48시간...)
   3. 광고보기
      1. 높은 재화 획득 가능, 특정 값 사이에서 랜덤 or 특정 값
   4. 훈련
      1. 앉아
      2. 기다려
      3. 손
      4. 하이파이브
7. 스테이터스
   1. 배고픔 : 밥 주면 회복
   2. 깨끗함 : 냥빨
   3. 재밌음 : 놀아주기, 쓰다듬기

#### 고양이 성장 및 이벤트 정리

|                | 아기고양이       | 어린이고양이          | 어른고양이          |
| -------------- | ---------------- | --------------------- | ------------------- |
| 누적플레이타임 | 0 ~6개월         | 6~12개월              | 12개월~             |
| 특정조건       | 없음             | 미정                  | 미정                |
| 이벤트         | 첫 목욕(4개월)   | 중성화선택(7개월이상) | 종합검진(6개월마다) |
|                | 젖니빠짐(6개월)  |                       |                     |
|                | 예방접종(50일경) |                       |                     |

#### 업그레이드

|           | 증가폭   | 업그레이드 가격 |
| --------- | -------- | --------------- |
| 직접 클릭 | 레벨 * 2 | 레벨 * 10       |
| 오토 클릭 | 레벨 * 2 | 레벨 * 10       |

####  

#### 오토클릭 종류 - 5초에 1번씩 획득

| 종류         | 금액 | 성능 | 위치        | 기타              |
| ------------ | ---- | ---- | ----------- | ----------------- |
| 스크래쳐     |      |      | 가운데      |                   |
| 미캉상자     |      |      | 왼쪽        |                   |
| 낚싯대장난감 |      |      | 오른쪽 아래 | [놀아주기] 활성화 |
| 캣타워       |      |      | 오른쪽      |                   |

#### 스크립트 정리

|            | 스크립트         | 변수                                                         | 함수                                                         | 게임오브젝트                                                 | UI                                                       | 기타                         |
| ---------- | ---------------- | ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ | -------------------------------------------------------- | ---------------------------- |
| 배경       |                  |                                                              |                                                              | Background Background_room Image_dish                        | Panel_Top(PT) Panel_Button(PB)                           |                              |
| 배경변화   | ChangeBackgorund | public GameObject prefabSky1;public GameObject prefabSky2;public GameObject prefabSky3;public int nowTime;LifeTime lifetime; | Start() Update() IEnumerator _ChangeBackground() ChangeSprite_Background_1() ChangeSprite_Background_2() ChangeSprite_Background_3() | Background                                                   |                                                          | 시간에 따라 배경변화         |
| 캐릭터     | HeartMove        | public Vector2 point;                                        | Start() Update()                                             |                                                              |                                                          |                              |
| 성장       | ChangeCat        | public GameObject prefabCat1;<br/>    public GameObject prefabCat2;<br/>    public GameObject prefabCat3;<br/><br/>    LifeTime lifetime; | Start()<br />Update()<br />_ChangeCat()<br />ChangeSprite_Cat_1()<br />ChangeSprite_Cat_2()<br />ChangeSprite_Cat_3() | Cat                                                          |                                                          |                              |
| GM         | GameManager      | public long heart;public long heartIncreaseAmount;public Text textHeart; public GameObject prefabHeart; | Start() Update() ShowInfo() HeartIncrease()                  | GameManager                                                  |                                                          |                              |
| 시간계산   | LifeTime         | public float LimitTime;public float ingameTime;public Text textTimer;public float timeSpeed; int timeYear;int timeMonth;int timeDay;int timeHour; | Start() Update() addLifeTime() CalTime() ShowInfo()          |                                                              | Text_timer(PT) Image_itmer_space(PT)                     |                              |
| 먹이주기   | GameManager      | public long foodPrice;public Button foodButton;public GameObject prefabFoodDish;public int food_lifeTime; | ButtonActiveCheck() feedPrice() ChangeSprite_Food()          |                                                              | Button_food(PB)                                          | 10초뒤에 먹이(이미지) 사라짐 |
| 업그레이드 | GameManager      | public long heart;public long heartIncreaseAmount;public long heartIncreaseLevel;public long heartIncreasePrice;public Text textHeart;public Text textHeartIncreasePrice;public Text textHeartUpgradePrice;public Button HeartIncreaseButton; | HeartIncrease() HeartIncreaseLevelUpgrade()  HeartIncreaseUpdatePanelText() HeartIncreaseUpdatePriceText() ButtonActiveCheck() |                                                              | Button_HeartIncrease(PB) Panel_HeartIncreasePriceUpgrade |                              |
| 장난감     | ToyManager       | public long ToyCreatePrice;<br/>    public long ToyIncreaseAmount;<br/>    public long ToyIncreaseLevel;<br/>    public long ToyIncreasePrice;<br/>    public string ToyName;<br/><br/>    public Text textToyIncreasePrice;<br/>    public Text textToyUpgradePrice;<br/>    public Button ToyIncreaseButton;<br/><br/>    public GameObject prefabToy;<br/><br/><br/>    GameManager gm;<br/><br/>    public Vector2 point; | Start()<br />Update()<br />IEnumerator autoClick()<br />ToyCreateButton()<br />public void ToyIncreaseLevelUpgrade()<br />ToyIncreaseUpdatePanelText()<br /> | ToyManager_Box<br />ToyManager_Scratcher<br />ToyManager_CatTower<br />ToyManager_Toy | Panel_Toy<br />Button_Toy(PB)                            |                              |
| 이벤트처리 |                  |                                                              |                                                              |                                                              |                                                          |                              |