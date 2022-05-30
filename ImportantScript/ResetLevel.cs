using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevel : MonoBehaviour
{
    public delegate void Levelreset();
    public static event Levelreset OnLevelReset;

    public static void ResetLevels() {

        if (OnLevelReset != null) {
            OnLevelReset();
        }
    }
}
