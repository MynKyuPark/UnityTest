using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaningScript : MonoBehaviour
{
    Image image;
    Color color;
    IEnumerator coWarn1, coWarn2;
    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        color = image.color;
        coWarn1 = Warning(0.01f, 0.66f, 0.01f);
        coWarn2 = Warning(0.1f, 0.33f, 0.005f);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerScript.Instance.Hp <= 0 || PlayerScript.Instance.Hp > 30)
        {
            StopAllCoroutines();
            color.a = 0;
            image.color = color;
        }
        else if (PlayerScript.Instance.Hp <= 15)
        {
            StopAllCoroutines();
            StartCoroutine(coWarn1);
        }
        else if (PlayerScript.Instance.Hp <= 30)
        {
            StopAllCoroutines();
            StartCoroutine(coWarn2);
        }
    }

    IEnumerator Warning(float time, float maxA, float plma)
    {
        while (true)
        {
            for (float i = 0; i <= maxA; i += plma)
            {
                color.a = i;
                image.color = color;
                yield return new WaitForSeconds(time);
            }

            yield return new WaitForSeconds(.5f);

            for (float i = maxA; i >= 0; i -= plma)
            {
                color.a = i;
                image.color = color;
                yield return new WaitForSeconds(time);
            }

            yield return new WaitForSeconds(.5f);
        }
    }
}
