using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    Rigidbody2D m_oRigid2D;
    [HideInInspector]
    public float m_fAxisX, m_fXclamp;
    PlayerAttack m_oChild;
    void Start()
    {
        m_oRigid2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (PlayerScript.Instance.Hp <= 0)
        {
            PlayerScript.Instance.m_fSpeed = 0;
            return;
        }

        Jump();

        Move();
    }
    void Move()
    {
        m_oChild = gameObject.GetComponentInChildren<PlayerAttack>();
        m_fAxisX = Input.GetAxis("Horizontal") * PlayerScript.Instance.m_fSpeed * Time.deltaTime;
        m_fXclamp = Mathf.Clamp(transform.position.x, -8.5f, 38.5f) + m_fAxisX;
        transform.position = new Vector2(m_fXclamp, transform.position.y);
        if (!m_oChild.isStateAtk)
        {
            if (m_fAxisX > 0)
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            else if (m_fAxisX < 0)
            {
                transform.localEulerAngles = new Vector3(0, 180, 0);
            }
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.DownArrow))
            return;
        else if (Input.GetKey(KeyCode.LeftAlt ) && m_oRigid2D.velocity == Vector2.zero/**/)
            m_oRigid2D.AddForce(Vector2.up * PlayerScript.Instance.m_fJump, ForceMode2D.Impulse);        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Road")
            m_oRigid2D.velocity = Vector2.zero;
    }
}