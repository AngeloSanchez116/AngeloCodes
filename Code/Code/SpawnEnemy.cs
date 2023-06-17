using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

//use a namespace
public class SpawnEnemy : MonoBehaviour
{
    //Good use of comments
    [Header("EnemySpawner")]
    [SerializeField]
    private List<EnemySpawnerSO> EnemySpawnerSoList; // Keep This code need for Final, This List is Connected with EnemySpawnBoundry
    [SerializeField]
    private EnemySpawnBoundrySO enemySpawnBoundry; //Keep this code need it for Final. Example: 0 on EnemySpawnerSoList Need to Match 0 for Start and Endpoints
    private EnemySpawnerSO enemySpawnerSO;
    private Transform camTransform; // Keep This Code need for Final

    [SerializeField]
    private float spawnTimer = .5f;
    [SerializeField]
    private float spawnResetTimer;
    [SerializeField]
    private bool turnOnOffSpawningEnemy = true;
    private int randEnemy;
    [SerializeField]
    private int spawnBoundryListValue;//The position of in the list for enemyspawnerSoList and EnemySpawnBoundry
    [SerializeField]
    private int perivousSboundryListValue;//Keep This Code

    private int previousnum;
    private bool spawnNewEnemy = true;

    private void Start()
    {
        if (camTransform == null)
        {
            camTransform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        }
        spawnBoundryListValue = 0;
        UpdateEnemySpawnerSo();

    }
    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0 && camTransform.position.x >= enemySpawnBoundry.startPoint[spawnBoundryListValue].x &&
                camTransform.position.x < enemySpawnBoundry.endPoint[spawnBoundryListValue].x) {

            if (spawnNewEnemy == true) {

                //Do you need the absolute value of a positive number? I think you can remove `Mathf.Abs`
                randEnemy = Mathf.Abs(Random.Range(0, enemySpawnerSO.enemy.Count));
                SpawnEnemies(enemySpawnerSO.enemy[randEnemy]);
            }
        }

        if (camTransform.position.x >= enemySpawnBoundry.startPoint[spawnBoundryListValue].x 
            && spawnBoundryListValue < enemySpawnBoundry.startPoint.Count) {

            perivousSboundryListValue = spawnBoundryListValue;
        }

        if (camTransform.position.x > enemySpawnBoundry.endPoint[spawnBoundryListValue].x)
        {
            spawnBoundryListValue++;
            UpdateEnemySpawnerSo();
        }
    }
    //Check if the camera is in enemy spawn boundry
    private void FixedUpdate()
    {
        //This doesn't need to be in FixedUpdate
        if (PlayerState.state == PlayerState.PlayerStates.Dead) {

            spawnBoundryListValue = perivousSboundryListValue;
        }
    }
    void SpawnEnemies(GameObject gameObject) {

        int num;
        float y;
        spawnNewEnemy = false;
        Rigidbody enemyrb;

        enemyrb =  gameObject.GetComponent<Rigidbody>();
        num = ChangeSameSpawnLocation();
        y = enemySpawnerSO.SpawnLoc[num].y;

        //You are instantiating a rigid body? if the goal is to instantiate the gameobject then you don't need the rigidbody for that
        Instantiate(enemyrb, new Vector3(transform.position.x, y, enemySpawnerSO.SpawnLoc[0].z), Quaternion.Euler(0f, 0f, 0f));

        spawnTimer = spawnResetTimer;
        spawnNewEnemy = true;
    }

    int ChangeSameSpawnLocation() {
        int randomnum;

        randomnum = Random.Range(0, enemySpawnerSO.SpawnLoc.Count);
        if (previousnum == randomnum)
        {
            return ChangeSameSpawnLocation();
        }

        previousnum = randomnum;
        return randomnum;  
    }
    //Okay the one thing I haven't seen you do which you should do more is to bake comments into your functions.

    //You do that by hitting the slash thre times above a function which adds automatic code ->  ///

    /// <summary>
    /// This is a baked in comment. When hovering over this method, you will now read this
    /// </summary>
    /// <param name="x">Doesn't matter</param>
    public void ExampleMethod(int x) { 
        
    }

    //Initializing the enemySpawerSO
    public void UpdateEnemySpawnerSo() {

        if (spawnBoundryListValue < enemySpawnBoundry.endPoint.Count) {
            enemySpawnerSO = EnemySpawnerSoList[spawnBoundryListValue];
        }
    }
}
