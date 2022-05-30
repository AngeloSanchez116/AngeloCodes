using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boobytrap : MonoBehaviour
{
    [Header("BoobyTrap")]
    public GameObject energySphere;
    public float energySpeed;
    private float timer = .5f;
    public float resettimer;
    public MeshRenderer boobytrapMeshRend;

    private void Awake()
    {
        boobytrapMeshRend = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        timer -= Time.deltaTime;

        if (boobytrapMeshRend.isVisible == true) {
            while (timer < 0)
            {

                if (CompareTag("BoobyTrap"))
                {
                    SpawnBoobytrap();
                }

                timer = resettimer;
            }
        }
    }

    void SpawnBoobytrap()
    {

        Rigidbody clone;
        clone = Instantiate(energySphere.GetComponent<Rigidbody>(), transform.position, transform.rotation);
        clone.velocity = transform.TransformDirection(Vector3.up * energySpeed);
        
    }
}
