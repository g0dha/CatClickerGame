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


    void Start()
    {
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
        SceneManager.LoadScene("1_Playing");
    }


}
