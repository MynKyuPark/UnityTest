using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotalScript : MonoBehaviour
{
    public GameObject nextPanel;
    CircleCollider2D circleCollider;
    SpriteRenderer render;
    void Awake()
    {
        render = gameObject.GetComponent<SpriteRenderer>();
        circleCollider = gameObject.GetComponent<CircleCollider2D>();
    }
    private void OnEnable()
    {
        render.enabled = true;
        circleCollider.enabled = true;
    }

    //private void OnDisable()
    //{
    //    StopAllCoroutines();
    //    Debug.Log("1");
    //}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                circleCollider.enabled = false;
                StartCoroutine(GoNextRound());
            }
        }
    }

    IEnumerator GoNextRound()
    {
        yield return new WaitForSeconds(1);
        nextPanel.SetActive(true);
        yield return new WaitForSeconds(4);
        PlayerScript.Instance.transform.position = new Vector3(15, -14.5f, 0);
        render.enabled = false;
        yield return new WaitForSeconds(5);
        RoundManager.Instance.isMonster = false;
        gameObject.SetActive(false);
    }
}
