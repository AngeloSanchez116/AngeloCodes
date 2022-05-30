using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody enemyRb;
    public EnemyTemplateSO enemyTemp;
    public float speed;
    public float speedMulti;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        speed = enemyTemp.speed;
        speedMulti = enemyTemp.speedMuti;
    }
    // Update is called once per frame
    void Update()
    {
        Enemymovement();
    }

    public void Enemymovement()
    {
        enemyRb.velocity = new Vector3(-(Time.deltaTime * speed) * speedMulti, 0f, 0f);
    }
}
