using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro_animation : MonoBehaviour
{
    public float StopTime;

    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public Sprite[] sprites_2;

    public GameObject speech;
    public Text textspeech;



    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[0];
        StartCoroutine("_changeLight");
    }

    void Update()
    {
        StopTime += Time.deltaTime;
        PopSpeech();
    }

    IEnumerator _changeLight()
    {
        while (StopTime < 3)
        {
            if (spriteRenderer.sprite == sprites[0])
            {
                spriteRenderer.sprite = sprites[1];
                yield return new WaitForSeconds(0.7f);
            }
            else if (spriteRenderer.sprite == sprites[1])
            {
                spriteRenderer.sprite = sprites[0];
                yield return new WaitForSeconds(0.3f);
            }
            if (StopTime >= 3)
            {
                spriteRenderer.sprite = sprites[1];
                yield return null;
            }
        }
    }

    void PopSpeech()
    {
        if (StopTime >= 4.5f)
        {
            speech.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                speech.SetActive(false);
                StartCoroutine("_closeup");
            }
        }
    }
    IEnumerator _closeup()
    {
        yield return null;

    }
}
