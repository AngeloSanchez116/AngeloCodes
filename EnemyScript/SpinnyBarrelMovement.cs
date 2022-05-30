
using UnityEngine;

public class SpinnyBarrelMovement : EnemyMovement
{
    public int rotationSpeed;
    public float timer;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.rotation = Quaternion.Euler(timer * rotationSpeed,0f,0f);
        Enemymovement();
    }
}
