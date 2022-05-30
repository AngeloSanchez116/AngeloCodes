using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstriodSpawner : MonoBehaviour
{
    public EnemySpawnerSO astroidSO;
    public Rigidbody astriods;

    private int num;
    private float timer;
    public int speed;
    public float resetimer;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            num = Random.Range(0, astroidSO.enemy.Count);
            AstroidSpawner(astroidSO.enemy[num]);
            timer = resetimer;
        }

    }

    void AstroidSpawner(GameObject gameObject)
    {
        astriods = gameObject.GetComponent<Rigidbody>();
        Rigidbody clone = Instantiate(astriods, new Vector3(astroidSO.SpawnLoc[num].x,Random.Range(-20f, 21f), Random.Range(1f, 21f)), Quaternion.identity);
        clone.velocity = Vector3.left * speed;
        timer = 3f;
    }
}