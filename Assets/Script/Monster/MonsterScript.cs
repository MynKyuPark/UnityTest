using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public GameObject soul;
    Rigidbody2D thisRigidBody2D;
    float side, posX, tempSpd;
    private float hp;
    public int minGold, maxGold;
    public float Hp
    {
        get { return hp; }
        set
        {
            if (hp > value)
                onHurt();
            hp = value;
            if (hp <= 0)
                Die();
        }
    }
    public float linkHp;
    public float spd;

    public delegate void OnHurtMst();

    public OnHurtMst onHurt;
    // Start is called before the first frame update
    void Start()
    {
        Hp = linkHp;
        thisRigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        tempSpd = spd;
        RoundManager.Instance.hpPlus += PlusHpToRound;
    }

    // Update is called once per frame
    void Update()
    {
        linkHp = Hp;
        if (linkHp <= 0)
        {
            spd = 0;
            return;
        }
        posX = PlayerScript.Instance.transform.position.x - gameObject.transform.position.x;
        MoveToPlayer(posX);
    }

    void PlusHpToRound()
    {
        Hp += RoundManager.Instance.Round;
    }

    void MoveToPlayer(float pos)
    {
        if (!gameObject.GetComponentInChildren<MonsterAttack>().isStateAtk)
        {
            spd = tempSpd;
            if (pos > 0)
            {
                side = 1;
                transform.localScale = new Vector3(1f, 1f, 0);
            }
            else if (pos < 0)
            {
                side = -1;
                transform.localScale = new Vector3(-1f, 1f, 0);
            }
        }
        else
        {
            spd = 0;
        }
        thisRigidBody2D.velocity = new Vector2(side * spd, thisRigidBody2D.velocity.y);
    }

    void Die()
    {
        gameObject.layer = 4;
        spd = 0;
        for (int i = 0; i < Random.Range(minGold, maxGold); i++)
        {
            Vector3 thisPos = transform.position;

            thisPos.x += Random.Range(-1.1f, 1.1f);
            thisPos.y += Random.Range(-1.1f, 1.1f);

            Instantiate(soul, thisPos, Quaternion.identity);
        }
        StartCoroutine(gameObject.GetComponent<MonsterAnime>().DieAnime());
    }
}
