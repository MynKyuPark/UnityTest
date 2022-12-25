using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMove : MonoBehaviour
{
    public GameObject icon;
    Rigidbody2D m_oRigid2D;
    Vector3 limVector;
    // Start is called before the first frame update
    void Start()
    {
        m_oRigid2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (icon.activeSelf)
        {
            return;
        }
        limVector = transform.position;

        limVector.x = Mathf.Clamp(transform.position.x, -8.5f, 29f);
        
        transform.position = limVector;
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * 7f * Time.deltaTime);
            transform.localScale = new Vector3(1,1,1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * 7f * Time.deltaTime);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        Jump();
    }

    void Jump()
        {
            if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.DownArrow))
                return;
            else if (Input.GetKey(KeyCode.LeftAlt) && m_oRigid2D.velocity == Vector2.zero/**/)
                m_oRigid2D.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
        }
}
