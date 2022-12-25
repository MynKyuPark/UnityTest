using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldMapScript : MonoBehaviour
{
    public GameObject enumBtns;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        StartCoroutine(WorldMap());
    }
    IEnumerator WorldMap()
    {
        yield return new WaitForSeconds(0.5f);
        for (float i = 0; i <= 1; i = i + 0.01f)
        {
            image.fillAmount = i;
            yield return new WaitForSeconds(0.005f);
        }
        enumBtns.SetActive(true);
    }
}
