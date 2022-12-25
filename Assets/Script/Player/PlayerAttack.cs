using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    SpriteRenderer sprite;
    Collider2D[] hits;
    Animator animator;
    bool coolTIme = true;
    bool sideCheck = false;
    public bool isStateAtk = false;
    float spd;
    [Range(-3f, 3f)]
    public float posX, posY, sizeX, sizeY, time1, time2, time3;
    IEnumerator coHurt;
    void Start()
    {
        PlayerScript.Instance.onHurt += DelStartCo;
        animator = GetComponent<Animator>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }
    void DelStartCo()
    {
        StartCoroutine(Hurt());
    }

    IEnumerator Hurt()
    {
        animator.SetTrigger("tHurt");

        PlayerScript.Instance.gameObject.layer = 2;

        int countWhile = 0;

        while (countWhile < 10)
        {
            if (countWhile % 2 == 0)
                sprite.color = new Color32(255, 255, 255, 85);
            else
                sprite.color = new Color32(255, 255, 255, 170);

            yield return new WaitForSeconds(.2f);

            countWhile++;
        }
        sprite.color = new Color(255, 255, 255, 255);

        PlayerScript.Instance.gameObject.layer = 6;
    }
    void Update()
    {
        if (PlayerScript.Instance.onHurt == null || !this.gameObject.activeSelf)
        {
            StopCoroutine(Hurt());
        }
        if (coolTIme)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                if (PlayerScript.Instance.isJunjicCheck)
                {
                    spd = 6;
                }
                else
                {
                    spd = 4;
                }
                StartCoroutine(AtkCoolTime());
            }
        }
        if (PlayerScript.Instance.transform.rotation.y != 0)
        {
            sideCheck = true;
        }
        else if (PlayerScript.Instance.transform.rotation.y == 0)
        {
            sideCheck = false;
        }
    }

    IEnumerator AtkCoolTime()
    {
        isStateAtk = true;
        Attacking();
        yield return new WaitForSeconds(time1);
        AttackStart(posX, posY, sizeX, sizeY);
        yield return new WaitForSeconds(time2);

        if (PlayerScript.Instance.isJunjicCheck)
        {
            AttackStart(posX, posY, sizeX, sizeY);
        }
        hits = null;
        isStateAtk = false;
        PlayerScript.Instance.m_fSpeed = spd;
        yield return new WaitForSeconds(time3);
        coolTIme = true;
    }

    void Attacking()
    {
        coolTIme = false;

        if (PlayerScript.Instance.isJunjicCheck)
        {
            PlayerScript.Instance.m_fSpeed = 4f;
        }
        else
        {
            PlayerScript.Instance.m_fSpeed = 2f;
        }

        animator.SetTrigger("testAtk");
    }

    void AttackStart(float posX, float posY, float sizeX, float sizeY)
    {
        int count = 0;
        if (sideCheck)
        {
            hits = Physics2D.OverlapBoxAll
               (gameObject.GetComponentInParent<Transform>().position
                + new Vector3(-posX, posY, 0), new Vector2(sizeX, sizeY), 0);
        }
        else
        {
            hits = Physics2D.OverlapBoxAll
                (gameObject.GetComponentInParent<Transform>().position
                + new Vector3(posX, posY, 0), new Vector2(sizeX, sizeY), 0);
        }
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].gameObject.layer == 8)
            {
                if (count <3)
                {
                    count++;
                    hits[i].GetComponent<MonsterScript>().Hp -= PlayerScript.Instance.m_fPower;
                }
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (sideCheck)
        {
            Gizmos.DrawWireCube(gameObject.GetComponentInParent<Transform>().position
                 + new Vector3(-posX, posY, 0), new Vector2(sizeX, sizeY));
        }
        else
        {
            Gizmos.DrawWireCube(gameObject.GetComponentInParent<Transform>().position
                + new Vector3(posX, posY, 0), new Vector2(sizeX, sizeY));
        }
    }
}
