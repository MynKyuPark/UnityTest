using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    Collider2D[] hits;
    GameObject parent;
    protected Animator animator;
    bool coolTImeMST = true, sideCheckMST = false;
    [HideInInspector]
    public bool isStateAtk = false;
    [Range(-3f, 3f)]
    public float posX, posY, sizeX, sizeY, time1, time2, time3;
    public float atk;
    IEnumerator attacking;
    // Start is called before the first frame update
    void Start()
    {
        attacking = AtkCoolTime();
        parent = gameObject.GetComponentInParent<MonsterScript>().gameObject;
        animator = parent.GetComponent<Animator>();
        gameObject.GetComponentInParent<MonsterScript>().onHurt += AttackStop;
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.transform.localScale.x > 0)
        {
            sideCheckMST = false;
        }
        else if (parent.transform.localScale.x < 0)
        {
            sideCheckMST = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if (coolTImeMST)
            {
                attacking = AtkCoolTime();
                isStateAtk = true;
                StartCoroutine(attacking);
            }
        }
    }
    public IEnumerator AtkCoolTime()
    {
        Attacking();
        yield return new WaitForSeconds(time1);
        AttackStart(posX, posY, sizeX, sizeY);
        yield return new WaitForSeconds(time2);
        hits = null;
        yield return new WaitForSeconds(time3);
        parent.GetComponent<MonsterScript>().spd = 2;
        isStateAtk = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        coolTImeMST = true;
    }

    void Attacking()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        coolTImeMST = false;

        parent.GetComponent<MonsterScript>().spd = 0;

        animator.SetTrigger("testAtk");
    }

    void AttackStart(float posX, float posY, float sizeX, float sizeY)
    {
        if (sideCheckMST)
        {
            hits = Physics2D.OverlapBoxAll
               (parent.transform.position
                + new Vector3(-posX, posY, 0), new Vector2(sizeX, sizeY), 0);
        }
        else
        {
            hits = Physics2D.OverlapBoxAll
                (parent.transform.position
                + new Vector3(posX, posY, 0), new Vector2(sizeX, sizeY), 0);
        }
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].gameObject.layer == 6)
            {
                PlayerScript.Instance.Hp -= atk;
                i = hits.Length;
            }
        }
    }
    void AttackStop()
    {
        StopAllCoroutines();
        StartCoroutine(HurtDelay());
    }

    IEnumerator HurtDelay()
    {
        parent.GetComponent<MonsterScript>().spd = 0;
        yield return new WaitForSeconds(.5f);
        isStateAtk = false;
        parent.GetComponent<MonsterScript>().spd = 2;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        coolTImeMST = true;
    }
}