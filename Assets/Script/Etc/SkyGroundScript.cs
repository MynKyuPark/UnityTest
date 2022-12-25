using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyGroundScript : MonoBehaviour
{
    public CompositeCollider2D m_oCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        m_oCollider2D.isTrigger = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.DownArrow))
        {
            m_oCollider2D.isTrigger = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6 || collision.gameObject.layer == 2)
        {
            m_oCollider2D.isTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 || collision.gameObject.layer == 2)
        {
            m_oCollider2D.isTrigger = false;
        }
    }
}
