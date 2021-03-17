using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public Vector2 point;
    public Vector2 EndPosition;

    public float DownSpeed;
    public float alpha;

    public GameObject button_Start;
    public GameObject CatFace;
    private string stringCatInfo_sc;


    void Start()
    {
        string path = Application.persistentDataPath + "/save.xml";
        if (System.IO.File.Exists(path))
        {
            Load();
        }

        

        EndPosition = new Vector2(point.x, point.y);
        DownSpeed = alpha * Time.deltaTime;
        CatFace.SetActive(false);
        button_Start.SetActive(false);
    }

    void Update()
    {
        StartCoroutine("MoveTitle");

        Pop_Image();
        Pop_Button();
    }

    IEnumerator MoveTitle()
    {
        if (transform.position.y > EndPosition.y)
        {
            transform.position -= new Vector3(0, DownSpeed, 0);

            if (transform.position.y <= EndPosition.y)
            {
                transform.position = new Vector3(EndPosition.x, EndPosition.y, 0);
                yield return null;
            }
        }
    }

    void Pop_Image()
    {
        if (transform.position.y == EndPosition.y)
        {
            CatFace.SetActive(true);
        }
    }

    void Pop_Button()
    {
        if ((transform.position.y == EndPosition.y) && (CatFace.activeSelf == true))
        {
            button_Start.SetActive(true);
        }
    }

    public void ChangePlayGameScene()
    {
        if (!(stringCatInfo_sc.Length==0))
        {
            Debug.Log("게임화면");
            SceneManager.LoadScene("1_Playing");
        }
        else if (stringCatInfo_sc.Length==0)
        {
            Debug.Log("인트로화면");
            SceneManager.LoadScene("0.1_intro");
        }
        else
        {
            SceneManager.LoadScene("0.1_intro");
        }


    }
    
    void Load()
    {
        SaveData saveData = new SaveData();
                Debug.Log("1");
        string path = Application.persistentDataPath + "/save.xml";
                Debug.Log("2");
        saveData = XmlManager.XmlLoad<SaveData>(path);
                Debug.Log("3");

        stringCatInfo_sc = saveData.stringCatInfo;
                Debug.Log("4");
        
    }


}
