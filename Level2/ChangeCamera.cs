using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject targetobj;

    public float journeyLength;
    public float time;
    public float distravel;

    public Vector3 newpostion;


    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetobj.transform.position, distravel);
    }

    public void Finddistancetravel() {

        journeyLength = Vector3.Distance(transform.position, targetobj.transform.position -= newpostion);
        print(targetobj.transform.position);
        distravel = time / journeyLength;
    }
}
