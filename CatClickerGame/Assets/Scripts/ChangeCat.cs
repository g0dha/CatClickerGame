using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCat : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    LifeTime lifetime;

    void Start()
    {
        lifetime = GameObject.Find("GameManager").GetComponent<LifeTime>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[0];

        StartCoroutine("_ChangeCat");

    }

    IEnumerator _ChangeCat()
    {
        if (lifetime.timeYear == 0 && lifetime.timeMonth == 0)
        {
            spriteRenderer.sprite = sprites[0];
            yield return null;
        }
        else if (lifetime.timeYear == 0 && lifetime.timeMonth == 6)
        {
            spriteRenderer.sprite = sprites[1];
            yield return null;
        }
        else if (lifetime.timeYear == 1 && lifetime.timeMonth == 0)
        {
            spriteRenderer.sprite = sprites[2];
            yield return null;
        }
    }

}
