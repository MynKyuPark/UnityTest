using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPanel : MonoBehaviour
{
    Image image;
    // Start is called before the first frame update
    void Awake()
    {
        image = gameObject.GetComponent<Image>();
    }
    private void OnEnable()
    {
        StartCoroutine(PanelColorA());
    }
    //private void OnDisable()
    //{
    //    StopAllCoroutines();
    //}
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PanelColorA()
    {
        Color color = image.color;
        for (float i = 0; i <= 1; i += 0.02f)
        {
            yield return new WaitForSeconds(0.05f);
            color.a = i;
            image.color = color;
        }
        RoundManager.Instance.Round++;
        yield return new WaitForSeconds(1f);
        for (float i = 1; i >= 0; i -= 0.02f)
        {
            yield return new WaitForSeconds(0.05f);
            color.a = i;
            image.color = color;
        }
        gameObject.SetActive(false);
    }
}
