using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnime : AnimatControl
{
    float axisX, posX, hurtX;
    // Start is called before the first frame update
    void Start()
    {
        charAnimate = gameObject.GetComponent<Animator>();
        gameObject.GetComponent<MonsterScript>().onHurt += Hurt;
    }

    // Update is called once per frame
    public override void Update()
    {
        axisX = gameObject.GetComponent<Rigidbody2D>().velocity.x;
        AnimeWalk(axisX);
    }
    void Hurt()
    {
        posX = PlayerScript.Instance.transform.position.x - gameObject.transform.position.x;
        if (posX > 0)
            hurtX = -.5f;
        else
            hurtX = .5f;
        gameObject.transform.Translate(new Vector3(hurtX, 0));
        charAnimate.SetTrigger("tHurt");
    }

    public IEnumerator DieAnime()
    {
        charAnimate.SetTrigger("tDie");
        yield return new WaitForSeconds(1.3f);
        Destroy(gameObject);
    }
}