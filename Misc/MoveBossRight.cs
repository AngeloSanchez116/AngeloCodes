using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBossRight : MonoBehaviour
{
    public float levelMovementSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * levelMovementSpeed * Time.deltaTime;
    }
}
