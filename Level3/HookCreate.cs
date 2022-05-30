using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookCreate : MonoBehaviour
{
    public float speed;


    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "TopCreate") {
            transform.position -= new Vector3(Time.deltaTime * speed, 0f, 0f);

            if (transform.position.x <= -350) {

                transform.position = new Vector3(528.2f, 161.74f, 129.463f);
            }
        }
        if (gameObject.tag == "bottomCreate")
        {
            transform.position += new Vector3(Time.deltaTime * speed, 0f, 0f);

            if (transform.position.x >= 565)
            {

                transform.position = new Vector3(-345.6f, 45.54f, 129.463f);
            }
        }
    }
}
