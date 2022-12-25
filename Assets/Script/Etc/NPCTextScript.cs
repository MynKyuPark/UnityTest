using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTextScript : MonoBehaviour
{
    string[] strText1 = { "��� ����\n�����.." , "�� �ʹ�\n�����.." , "���� ��\n���ݾ�.." , "���� �ϰ�\n���� ����.." };
    string[] strText2 = { "���� �Ϸ�\n�ö󰡰�" , "����\n�־��� ?", "�׳� ����\n���� ?", "��� �� ��\n���ϱ� ?" };
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
