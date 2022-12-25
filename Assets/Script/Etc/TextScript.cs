using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    Text text;
    Color color;
    bool ischeck = true;
    public bool isCheckBlackBoard = false;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        color = text.color;
        StartCoroutine(Test1());
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && ischeck)
        {
            StopCoroutine(Test1());
            ischeck = false;
            StartCoroutine(Test2());
        }
    }

    IEnumerator Test1()
    {
        while (ischeck)
        {
            for (float i = 0; i <= 1; i += 0.02f)
            {
                color.a = i;
                text.color = color;
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(.5f);
            for (float i = 1; i >= 0; i -= 0.02f)
            {
                yield return new WaitForSeconds(0.01f);
                color.a = i;
                text.color = color;
            }
            yield return new WaitForSeconds(.5f);
        }
    }

    IEnumerator Test2()
    {
        int count = 0;
        while (count < 5)
        {
            count++;
            for (float i = 0; i <= 1; i += 0.1f)
            {
                color.a = i;
                text.color = color;
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(.1f);
            for (float i = 1; i >= 0; i -= 0.1f)
            {
                yield return new WaitForSeconds(0.01f);
                color.a = i;
                text.color = color;
            }
        }
        isCheckBlackBoard = true;
    }
}
