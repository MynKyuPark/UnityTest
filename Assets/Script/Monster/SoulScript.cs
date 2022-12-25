using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulScript : MonoBehaviour
{
    Animator animator;
    GameObject soul;
    bool ischeck = false;
    Rigidbody2D rb2D;
    float spd;
    IEnumerator ienum;
    // Start is called before the first frame update
    void Start()
    {
        ienum = GoldDrop();
        animator = gameObject.GetComponent<Animator>();
        soul = FindObjectOfType<MainCameraScript>().transform.GetChild(0).gameObject;
        rb2D = GetComponent<Rigidbody2D>();
        StartCoroutine(ienum);
        spd = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (ischeck)
        {
            StopCoroutine(ienum);
            gameObject.transform.Translate((soul.transform.position - gameObject.transform.position).normalized * Time.deltaTime * spd);
            spd += 0.2f;
        }
    }

    IEnumerator GoldDrop()
    {
        yield return new WaitForSeconds(1);
        rb2D.gravityScale = 0;
        ischeck = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 5)
        { 
            PlayerScript.Instance.gold += 5;
            StartCoroutine(GoldDest());
        }
    }

    IEnumerator GoldDest()
    {
        PlayerScript.Instance.gold += 5;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        animator.SetTrigger("getGold");
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
