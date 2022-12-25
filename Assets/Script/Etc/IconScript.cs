using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IconScript : MonoBehaviour
{
    public GameObject icons;
    Image[] image;
    private void Start()
    {
        image = icons.GetComponentsInChildren<Image>();
    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(IconsSetFalse());
    }

    IEnumerator IconsSetFalse()
    {
        Color color = image[0].color;

        for (float j = 1; j >= 0; j-= 0.01f)
        {
            color.a = j;
            for (int i = 0; i < image.Length; i++)
            {
                image[i].color = color;
            }
            yield return new WaitForSeconds(0.005f);
        }
        yield return new WaitForSeconds(.5f);
        icons.SetActive(false);
    }
}
