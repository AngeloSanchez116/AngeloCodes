using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{   
    public SpinnyBarrelMovement enemyRotationSpeed;
    public float shootTimeReset;
    public float shootTimer;
    public GameObject gun1;
    public GameObject gun2;
    public Rigidbody bullet;
    
    // Start is called before the first frame update
    void Awake()
    {
        enemyRotationSpeed = GetComponent<SpinnyBarrelMovement>();
        shootTimer = 180f / enemyRotationSpeed.rotationSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        if (shootTimeReset >= shootTimer)
        {
          Rigidbody clone;
          if (gun1 != null)
          {
            clone = Instantiate(bullet, gun1.transform.position, gun1.transform.rotation);
            clone.velocity = transform.TransformDirection(Vector3.left * 10f);
            shootTimeReset = 0;
          }
        }
        
        shootTimeReset += Time.deltaTime;
    }
}
