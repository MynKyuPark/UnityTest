using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : Singleton<RoundManager>
{

    public delegate void HpPlus();
    public HpPlus hpPlus;

    private int n_iRound;
    public int Round
    {
        get 
        { 
            return n_iRound; 
        }
        set 
        {
            n_iRound = value; 
        }
    }
    MonsterScript monster;
    public GameObject[] m_oMonster;
    public GameObject potal;
    public GameObject Store;
    [HideInInspector]
    public Animator anime;
    public bool isMonster;

    void Start()
    {
        potal.SetActive(false);
        anime = gameObject.GetComponent<Animator>();
        Round = 1;
        RoundAsMonster(Round, 6 + (2 * Round / 4));
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 && isMonster && monster == null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Store.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            StartCoroutine(Store.GetComponent<StoreScript>().BoardBye());

        }
    }

    void Update()
    {
        monster = FindObjectOfType<MonsterScript>();
        if (Round > 0)
        {
            if (isMonster && monster == null)
            {
                potal.SetActive(true);
                anime.SetBool("isOpenPotal", true);
            }
            else
            {
                anime.SetBool("isOpenPotal", false);
            }

            if (!isMonster)
            {
                RoundAsMonster(Round, 6 + (2 * Round / 4));
            }
        }
    }
    void RoundAsMonster(int a_Round, int a_MonsterNum)
    {
        switch (a_Round % 4)
        {
            case 1:
                StartCoroutine(MonsterCreate(0, a_MonsterNum));
                break;
            case 2:
                StartCoroutine(MonsterCreate(1, a_MonsterNum));
                break;
            case 3:
                StartCoroutine(MonsterCreate(2, a_MonsterNum));
                break;
            case 0:
                StartCoroutine(MonsterCreate(3, a_MonsterNum / 2));
                break;
        }
    }

    IEnumerator MonsterCreate(int a_MonterIndex, int a_MonsterNum)
    {
        isMonster = true;
        for (int i = 0; i < 1; i++)
        {
            if (i % 2 == 0)
            {
                Instantiate(m_oMonster[a_MonterIndex], new Vector3(-5.5f, -15f, 0), Quaternion.identity).SetActive(true);
            }
            else
            {
                Instantiate(m_oMonster[a_MonterIndex], new Vector3(35.5f, -15f, 0), Quaternion.identity).SetActive(true);
            }
            yield return new WaitForSeconds(.7f);
        }
    }
}