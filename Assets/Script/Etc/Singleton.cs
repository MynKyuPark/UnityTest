using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_oInstance = null;

    public static T Instance
    {
        get
        {
            m_oInstance = FindObjectOfType(typeof(T)) as T;

            if (m_oInstance == null)
            {
                GameObject oGamObject = new GameObject(typeof(T).ToString());
                m_oInstance = oGamObject.AddComponent<T>();
            }
            return m_oInstance;
        }
    }
}