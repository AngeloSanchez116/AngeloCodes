using System.Collections.Generic;
using UnityEngine;

public class TurnOnAlertOnTrigger : MonoBehaviour
{
    public bool turnOnAlarm = false;
    public int counter;

    public delegate void AlarmActivate();
    public static event AlarmActivate OnAlarmActivate;
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {

            OnAlarmActivate();
        }
    }
}
