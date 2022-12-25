using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
public class MainCameraScript : MonoBehaviour
{
    [SerializeField]
    public Transform m_oPlayer;
    float n_fXclmp, n_fYclmp;
    private void Update()
    {
        transform.position = new Vector3(m_oPlayer.position.x, m_oPlayer.position.y, -10f);


        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (PlayerScript.Instance.Hp <= 0)
            {
                transform.position += new Vector3(0, -2.5f, 7f);
                PlayerScript.Instance.gameObject.layer = 2;
            }

            n_fXclmp = Mathf.Clamp(transform.position.x, 1.3f, 28.6f);
            n_fYclmp = Mathf.Clamp(transform.position.y, -12.1f, -7.7f);
        }
        else
        {
            n_fXclmp = Mathf.Clamp(transform.position.x, 1.3f, 20f);
            n_fYclmp = Mathf.Clamp(transform.position.y, -12.1f, -7.7f);
        }
        
        transform.position = new Vector3(n_fXclmp, n_fYclmp, -10f);
    }
}