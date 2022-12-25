using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoGame : MonoBehaviour
{
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        StartCoroutine(Screen());
    }
    IEnumerator Screen()
    {
        Color color = image.color;
        for (float i = 0; i < 1; i+=0.01f)
        {
            color.a = i;
            image.color = color;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Game");
    }
}
