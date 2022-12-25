using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    GameObject parent;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        PlayerScript.Instance.onHurt += DelStartCo;
        parent = transform.parent.gameObject;
        image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {        
        if(PlayerScript.Instance.onHurt == null)
        {
            StopAllCoroutines();
        }
        image.fillAmount = PlayerScript.Instance.Hp / 100;
        transform.GetChild(0).gameObject.GetComponent<Text>().text = PlayerScript.Instance.Hp.ToString();
    }
    void DelStartCo()
    {
        StartCoroutine(Shake());
    }
    IEnumerator Shake()
    {
        Vector3 originPos = parent.transform.position;
        for (int i = 0; i < 10; i++)
        {
            float rdX = Random.Range(-2f, 2f);
            float rdY = Random.Range(-2f, 2f);
            parent.transform.position += new Vector3(rdX, rdY, 0);
            yield return new WaitForSeconds(.1f);
            parent.transform.position = originPos;
        }
    }
}
