using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : Singleton<PlayerScript>
{
    public float m_fSpeed, m_fJump, m_fPower, m_fSkillPower;
    public int gold;
    public GameObject gameOverPanel;
    public bool isJunjicCheck = false;

    public delegate void HurtDel();
    public HurtDel onHurt = null;

    public delegate void DieDel();
    public DieDel onDie = null;

    private float hp;
    public float Hp
    {
        get { return hp; }
        set
        {
            if (hp > value)
            {
                onHurt();
            }
            hp = value;
            if (hp <= 0)
            {
                hp = 0;
                onHurt = null;
                onDie();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = 6;
        Hp = 10;
        m_fSpeed = 4f;
        m_fJump = 9.5f;
        m_fPower = 20f;
        gold = 5000;
        m_fSkillPower = m_fPower * 2f;
        onDie += Die;
    }

    void Die()
    {
        gameOverPanel.SetActive(true);
    }

    private void Update()
    {
        if (transform.GetChild(0).gameObject.activeSelf)
        {
            isJunjicCheck = false;
        }
        else if (transform.GetChild(1).gameObject.activeSelf)
        {
            isJunjicCheck = true;
        }
    }
}
