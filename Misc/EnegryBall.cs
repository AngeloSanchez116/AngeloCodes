using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnegryBall : MonoBehaviour
{

    private void Update()
    {
        Destroy(gameObject,4f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shootable"))
        {
            Destroy(gameObject);
        }
    }
}
