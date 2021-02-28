using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartMove : MonoBehaviour
{
    public Vector2 point;

    // Start is called before the first frame update
    void Start()
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, point, Time.deltaTime * 10f);
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - 0.01f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(point, 0.2f);
    }
}
