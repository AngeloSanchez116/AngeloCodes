using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControl : MonoBehaviour
{
    public float speed;
    public float acceleration;
    public ParticleSystem rightEngine;
    public ParticleSystem leftEngine;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(0,180,0), Quaternion.Euler(-30, 180, 0), Time.deltaTime * speed);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(-30, 180, 0), Quaternion.Euler(0, 180, 0), Time.deltaTime * speed);
            
        }

        if (Input.GetKey(KeyCode.A))
        {
            BoosterPower(3);
        }
        else if (Input.GetKeyUp(KeyCode.A)) 
        {
            StandardFlames();
        }

        if (Input.GetKey(KeyCode.D))
        {
            BoosterPower(20);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            StandardFlames();
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, 180, 0), Quaternion.Euler(30, 180, 0), Time.deltaTime * speed);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(30, 180, 0), Quaternion.Euler(0, 180, 0), Time.deltaTime * speed);
            
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A)) {
            rb.velocity = new Vector3(-acceleration, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector3(0f, -acceleration, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(acceleration, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector3(0f, acceleration, 0f);
        }
 
    }

    private void BoosterPower(int num) {

        var startspeed = rightEngine.main;
        var startspeed_2 = leftEngine.main;
        startspeed.startSpeed = -num;
        startspeed_2.startSpeed = -num;
    }

    private void StandardFlames() {

        var startspeed = rightEngine.main;
        var startspeed_2 = leftEngine.main;
        startspeed.startSpeed = -6f;
        startspeed_2.startSpeed = -6f;

    }

    private void StopVelocity() {

        rb.velocity = new Vector3(0f,0f,0f);
    }
    
}
