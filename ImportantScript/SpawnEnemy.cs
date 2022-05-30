using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("EnemySpawner")]
    public EnemySpawnerSO enemySpawnerSO;

    public float spawnTimer;
    public float spawnResetTimer;

    public int spawnEnemyCount;
    public int nummberOfEnemySpawned;

    private float spawnOffSet;
    public float offSetTimer;

    private float y;
    private int previousnum;

    public Rigidbody enemyrb;


    public int randnum;

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;


        while (spawnTimer < 0) {

            spawnOffSet = 0f;
            randnum = Mathf.Abs(Random.Range(0, enemySpawnerSO.enemy.Count));
            SpawnEnemies(enemySpawnerSO.enemy[randnum]);
        };

    }

    void SpawnEnemies(GameObject gameObject) {
        int num;
        enemyrb =  gameObject.GetComponent<Rigidbody>();

        Instantiate(enemyrb, new Vector3(transform.position.x, y, -4.43f), Quaternion.Euler(-11.876f, 218.154f, 86.388f));
        spawnEnemyCount++;

        if (spawnEnemyCount >= nummberOfEnemySpawned) {

            num = ChangeSameSpawnLocation(); 
            y = enemySpawnerSO.SpawnLoc[num].y;
            spawnOffSet = offSetTimer;
        }
        else
        {
            spawnOffSet = 0f;
        }
        spawnTimer = spawnResetTimer + spawnOffSet;
    }

    int ChangeSameSpawnLocation() {
        int num;

        num = Random.Range(0, 3);
        if (previousnum == num)
        {
            return ChangeSameSpawnLocation();
        }
        spawnEnemyCount = 0;
        previousnum = num;
        return num;
        
    }
}
