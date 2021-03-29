using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class ChangeCat : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    GameManager gm;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[0];

    }

    void Update()
    {
        if (gm.PlayTime.TotalDays.ToString("######") == "1")
        {
            spriteRenderer.sprite = sprites[0];
        }
        if (gm.PlayTime.TotalDays.ToString("######") == "181")
        {
            spriteRenderer.sprite = sprites[1];
        }
        if (gm.PlayTime.TotalDays.ToString("######") == "366")
        {
            spriteRenderer.sprite = sprites[2];
        }
    }

}
