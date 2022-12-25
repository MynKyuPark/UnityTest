using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTextScript : MonoBehaviour
{
    string[] strText1 = { "언능 적을\n잡아줘.." , "나 너무\n힘들다.." , "내가 다\n하잖아.." , "빨리 하고\n집에 가자.." };
    string[] strText2 = { "빨리 하렴\n올라가게" , "아직\n멀었니 ?", "그냥 집에\n갈까 ?", "잠깐 눈 좀\n붙일까 ?" };
    MonsterScript monster;
    Text text;
    bool check = false;
    float timeCheck = 0;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        monster = FindObjectOfType<MonsterScript>();
        if (!check)
        {
            int rd = Random.Range(0, 4);
            if (monster != null)
            {
                text.text = strText1[rd];
            }
            else
            {
                text.text = strText2[rd];
            }
            check = true;
        }
        timeCheck += Time.deltaTime;

        if (timeCheck > 2)
        {
            timeCheck = 0;
            check = false;
        }
    }

    IEnumerator RdText()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
        }
    }
}
