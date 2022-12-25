using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StoreScript : MonoBehaviour
{
    int needGold1 = 100;
    int needGold2 = 100;
    int needGold3 = 1000;
    int needGold4 = 5000;
    int skillCount1 = 1;
    int skillCount2 = 1;
    int skillCount3 = 1;
    bool isFirst;
    public Text explanation;
    
    IEnumerator BoardStart()
    {
        for (float i = 0; i <= 1; i+=.01f)
        {
            gameObject.GetComponent<Image>().fillAmount = i;
            yield return new WaitForSeconds(0.01f);
        }
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public IEnumerator BoardBye()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        for (float i = 1; i >= 0; i -= .01f)
        {
            gameObject.GetComponent<Image>().fillAmount = i;
            yield return new WaitForSeconds(0.01f);
        }
        gameObject.SetActive(false);
    }
    void Start()
    {
        explanation.text = "";
        StartCoroutine(BoardStart());
    }

    private void OnEnable()
    {
        explanation.text = "";
        StartCoroutine(BoardStart());
    }
    // Update is called once per frame
    void Update()
    {

    }


    void UpSkill(ref int needGold, ref int count, int num)
    {
        string strText;
        if (needGold <= PlayerScript.Instance.gold)
        {
            PlayerScript.Instance.gold -= needGold;
            switch (num)
            {
                case 0:
                    PlayerScript.Instance.m_fPower *= 1.01f;
                    strText = "공격력 " + count + "Lv 강화  성공";
                    needGold = 100 * (count + 1);
                    break;
                case 1:
                    PlayerScript.Instance.m_fSpeed *= 1.01f;
                    strText = "이동속도 " + count + "Lv 강화  성공";
                    needGold = 100 * (count + 1);
                    break;
                case 2:
                    PlayerScript.Instance.Hp += 10;
                    strText = "체력 " + 10 + " 회복 성공";
                    needGold = 100 * (count + 1);
                    break;
                default:
                    strText = "";
                    break;
            }
            count++;
            explanation.text = strText;
            EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text = needGold + "Soul (" + count + "Lv)";
        }
        else
        {
            explanation.text = "강화를 위해 필요한 영혼이 부족합니다";
        }
    }
    public void UpAttack()
    {
        UpSkill(ref needGold1, ref skillCount1, 0);
    }

    public void UpSpeed()
    {
        UpSkill(ref needGold2, ref skillCount2, 1);
    }

    public void Healing()
    {
        UpSkill(ref needGold3, ref skillCount3, 2);
    }

    public void Upgrade()
    {
        if (!isFirst)
        {
            if (needGold4 <= PlayerScript.Instance.gold)
            {
                PlayerScript.Instance.gold -= needGold4;
                PlayerScript.Instance.transform.GetChild(1).gameObject.SetActive(true);
                PlayerScript.Instance.transform.GetChild(0).gameObject.SetActive(false);
                explanation.text = "전직 성공";
                isFirst = true;
                EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text = "재전직 가능";
            }
            else
            {
                explanation.text = "전직을 위해 필요한 기운이 부족합니다";
            }
        }
        else if (isFirst)
        {
            if (!PlayerScript.Instance.isJunjicCheck)
            {
                PlayerScript.Instance.transform.GetChild(1).gameObject.SetActive(true);
                PlayerScript.Instance.transform.GetChild(0).gameObject.SetActive(false);
                PlayerScript.Instance.gold -= needGold4;
                explanation.text = "재전직 성공";
                EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text = "재전직 가능";
            }
            else if (PlayerScript.Instance.isJunjicCheck)
            {
                PlayerScript.Instance.transform.GetChild(0).gameObject.SetActive(true);
                PlayerScript.Instance.transform.GetChild(1).gameObject.SetActive(false);
                PlayerScript.Instance.gold -= needGold4;
                explanation.text = "재전직 성공";
                EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text = "재전직 가능";
            }
        }
    }

    public void Eixt()
    {
        StartCoroutine(BoardBye());
    }
}
