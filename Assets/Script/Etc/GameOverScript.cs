using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{    
    void Start()
    {
        StartCoroutine(GameOver());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GameOver()
    {
        Color color = gameObject.GetComponent<Image>().color;
        Color color1 = transform.GetChild(0).gameObject.GetComponent<Text>().color;
        for (float i = 0; i <= 1; i += 0.02f)
        {
            color.a = i;
            color1.a = i;
            gameObject.GetComponent<Image>().color = color;
            transform.GetChild(0).gameObject.GetComponent<Text>().color = color1;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
