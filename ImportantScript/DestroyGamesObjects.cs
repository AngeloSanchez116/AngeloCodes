using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGamesObjects : MonoBehaviour
{
    public delegate void ClearGameObjects();
    public static event ClearGameObjects ClearedAllGameObjs;

    public static void OnObjectDestroy()
    {
        if (ClearedAllGameObjs != null) {
            ClearedAllGameObjs();
        }
    }
}
