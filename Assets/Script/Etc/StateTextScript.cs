using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StateTextScript : MonoBehaviour
{
    public int a;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ShowText(a);
    }

    void ShowText(int a)
    {
        string strText;
        if (a == 0)
        {
            strText = RoundManager.Instance.Round + " Ãþ";
        }
        else
        {
            strText = PlayerScript.Instance.gold.ToString();
        }

        text.text = strText;
    }
}
