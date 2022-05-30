using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoryOnloadScript : MonoBehaviour
{
    private GameObject instance = null;
    void Awake()
    {

        if (instance == null)
        {
            instance = gameObject;
            DontDestroyOnLoad(gameObject);
        }
    }

}
