using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlackBoardScript : MonoBehaviour
{
    TextScript text;
    Image image;
    public GameObject worldMap;
    public GameObject[] icon;
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        text = FindObjectOfType<TextScript>();
        if (text != null)
        {
            if (text.isCheckBlackBoard)
            {
                text.isCheckBlackBoard = false;
                StartCoroutine(CoBlackBoard());
            }
        }
    }
    IEnumerator CoBlackBoard()
    {
        for (float i = 0; i <= 1; i += 0.01f)
        {
            image.fillAmount = i;
            yield return new WaitForSeconds(0.005f);
        }

        yield return new WaitForSeconds(0.3f);

        for (int i = 0; i < icon.Length; i++)
        {
            icon[i].SetActive(false);
        }
        worldMap.SetActive(true);
    }
    IEnumerator ChangeScene()
    {
        Color color = btn.image.color;
        int count = 0;
        while (count < 5)
        {
            count++;
            for (float i = 1; i >= 0; i -= 0.1f)
            {
                yield return new WaitForSeconds(0.01f);
                color.a = i;
                btn.image.color = color;
            }
            yield return new WaitForSeconds(.1f);
            for (float i = 0; i <= 1; i += 0.1f)
            {
                color.a = i;
                btn.image.color = color;
                yield return new WaitForSeconds(0.01f);
            }
        }

        yield return new WaitForSeconds(.5f);

        worldMap.GetComponent<WorldMapScript>().enumBtns.SetActive(false);

        for (float i = 1; i >= 0; i -= 0.01f)
        {
            worldMap.GetComponent<Image>().fillAmount = i;
            yield return new WaitForSeconds(0.005f);
        }

        yield return new WaitForSeconds(.5f);

        worldMap.SetActive(false);

        SceneManager.LoadScene("Game");
    }
    public void ClickStart()
    {
        StartCoroutine(ChangeScene());
    }
}
