using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{

    public Transform door;
    public Transform door2;
    public bool dooropener = false;

    public float maxHieght;
    public float minHieght;

    private void Start()
    {
        maxHieght = door.transform.position.y + 10f;
        minHieght = door2.transform.position.y - 14f;
    }

    private void FixedUpdate()
    {

        if (dooropener == true && door2.transform.position.y >= minHieght) {
            
            door.transform.position += new Vector3(0, Time.deltaTime, 0);
            door2.transform.position -= new Vector3(0, Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            
            dooropener = true;
        }
    }
}
