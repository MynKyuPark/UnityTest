using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        StartCoroutine(CoStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CoStart()
    {
        for (float i = 1; i >= 0; i -= 0.02f)
        {
            image.fillAmount = i;
            yield return new WaitForSeconds(0.01f);
        }
        gameObject.SetActive(false);
    }
}
