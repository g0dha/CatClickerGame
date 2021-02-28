using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClick : MonoBehaviour
{

    public static long AutoHeartIncreaseAmount;
    public static long AutoIncreasePrice;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(autoClick());
    }

    // Update is called once per frame
    IEnumerator autoClick()
    {
        while (true)
        {
            GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            gm.heart += AutoHeartIncreaseAmount;

            yield return new WaitForSeconds(5);
        }
    }
}
