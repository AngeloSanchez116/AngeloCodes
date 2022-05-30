using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLevel : MonoBehaviour
{
    public MoveLevel mCamera;

    private void Start()
    {
        mCamera = FindObjectOfType<MoveLevel>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            
                mCamera.enabled = false;
            
        }
    }
}
