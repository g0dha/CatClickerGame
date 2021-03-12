using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangeBackground : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    public int nowTime;
    
    LifeTime lifetime;

    void Start()
    {
        lifetime = GameObject.Find("GameManager").GetComponent<LifeTime>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[0];
        
        StartCoroutine("_ChangeBackground");

    }

    void Update()
    {
        nowTime = lifetime.timeHour;
    }
    
    IEnumerator _ChangeBackground()
    {
        while (true)
        {
            switch (nowTime)
            {
                case 0:
                    spriteRenderer.sprite = sprites[2];
                    yield return null;
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    spriteRenderer.sprite = sprites[2];
                    yield return null;
                    break;
                case 7:
                    spriteRenderer.sprite = sprites[0];
                    yield return null;
                    break;
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    spriteRenderer.sprite = sprites[0];
                    yield return null;
                    break;
                case 16:
                    spriteRenderer.sprite = sprites[1];
                    yield return null;
                    break;
                case 17:
                case 18:
                case 19:
                    spriteRenderer.sprite = sprites[1];
                    yield return null;
                    break;
                case 20:
                    spriteRenderer.sprite = sprites[2];
                    yield return null;
                    break;
                case 21:
                case 22:
                case 23:
                    spriteRenderer.sprite = sprites[2];
                    yield return null;
                    break;

            }
        }
    }
    
}
