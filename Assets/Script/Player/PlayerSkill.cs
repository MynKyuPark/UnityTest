using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    Collider2D[] hitSkill;
    Animator animator;
    bool coolTIme1 = true;
    float spd;
    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }
    void Update()
    {
        if (coolTIme1)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                StartCoroutine(AtkCoolTime());
            }
        }
    }
    IEnumerator AtkCoolTime()
    {
        GetComponentInParent<PlayerAttack>().isStateAtk = true;
        Attacking();
        yield return new WaitForSeconds(.5f);
        AttackStart(0, -0.5f, 5, 3);
        yield return new WaitForSeconds(.5f);
        hitSkill = null;
        GetComponentInParent<PlayerAttack>().isStateAtk = false;
        if (PlayerScript.Instance.isJunjicCheck)
        {
            spd = 6;
        }
        else
        {
            spd = 4;
        }
        PlayerScript.Instance.m_fSpeed = spd;
        yield return new WaitForSeconds(1.7f);
        coolTIme1 = true;
    }

    void Attacking()
    {
        coolTIme1 = false;

        if(PlayerScript.Instance.isJunjicCheck)
        {
            PlayerScript.Instance.m_fSpeed = 3f;
        }
        else
        {
            PlayerScript.Instance.m_fSpeed = 1f;
        }

        animator.SetTrigger("skill");

    }

    void AttackStart(float posX, float posY, float sizeX, float sizeY)
    {
        hitSkill = Physics2D.OverlapBoxAll
            (gameObject.GetComponentInParent<Transform>().position
            + new Vector3(posX, posY, 0), new Vector2(sizeX, sizeY), 0);
        for (int i = 0; i < hitSkill.Length; i++)
        {
            if (hitSkill[i].gameObject.layer == 8)
            {
                if (PlayerScript.Instance.isJunjicCheck)
                {
                    hitSkill[i].transform.GetChild(2).gameObject.SetActive(true);
                    hitSkill[i].GetComponent<MonsterScript>().Hp -= (PlayerScript.Instance.m_fSkillPower * 1.5f);
                }
                else
                {
                    hitSkill[i].transform.GetChild(1).gameObject.SetActive(true);
                    hitSkill[i].GetComponent<MonsterScript>().Hp -= PlayerScript.Instance.m_fSkillPower;
                }                    
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawWireCube(gameObject.GetComponentInParent<Transform>().position
            + new Vector3(0, -0.5f, 0), new Vector2(5, 3));
    }
}
