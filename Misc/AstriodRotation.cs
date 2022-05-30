using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstriodRotation : MonoBehaviour
{
    public float xrotation;
    public float yrotation;
    public float zrotation;
    public float speed = 0.01f;

    private void Start()
    {
        xrotation = Random.Range(1f, 359f);
        yrotation = Random.Range(1f, 359f);
        zrotation = Random.Range(1f, 359f);
    }

    private void Update()
    {
        transform.Rotate(xrotation* speed * Time.deltaTime, yrotation *speed* Time.deltaTime, zrotation *speed* Time.deltaTime,Space.World);
        
    }
}
