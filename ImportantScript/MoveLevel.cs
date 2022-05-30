using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveLevel : MonoBehaviour
{
    public VectorPosition_BetweenTwoPointsSO vpBetweenTwoPoint;
    public static int currentEnemySpawn = 0;
    public static int perivousCurrentEnemySpawn;

    public float levelMovementSpeed;
    public bool spawnEnemy = true;
    public GameObject enemySpawer;
    public SpawnEnemy _spawnEnenyScript;
    public ChangeCamera changeCamera;
    public Transform camTransform;

    public bool movecamerax;
    public bool movecameray;
    public bool negmovecamerax;
    public bool negmovecameray;
    public bool trailerview;

    public Vector3 cameraStartlocation;
    private void Awake()
    {
        _spawnEnenyScript = GetComponentInChildren<SpawnEnemy>();
        changeCamera = GetComponent<ChangeCamera>();
    }
    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "Game")
        {
            transform.position = cameraStartlocation;
        }

        camTransform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            if (movecamerax == true)
            {
                transform.position += transform.right * levelMovementSpeed * Time.deltaTime;
            }
            else if (movecameray == true)
            {
                transform.position += transform.up * levelMovementSpeed * Time.deltaTime;
            }
            else if (negmovecamerax == true)
            {
                transform.position -= transform.right * levelMovementSpeed * Time.deltaTime;
            }
            else if (negmovecameray == true)
            {
                transform.position -= transform.up * levelMovementSpeed * Time.deltaTime;
            }

            if (SceneManager.GetActiveScene().name == "Game")
            {
                if (vpBetweenTwoPoint == null) {
                vpBetweenTwoPoint = Resources.Load("SavingPostionBetweenTwoPoints_For_Level1") as VectorPosition_BetweenTwoPointsSO;
                }

                if (spawnEnemy == true)
                {
                    TurningOnOffSpawnEnemy();
                }
            }
            else if (SceneManager.GetActiveScene().name == "Game_Level2")
            {

                if (spawnEnemy == true)
                {

                    Level2EnemySpawn();
                }

                stopcameracontroller();
            }
            else if (SceneManager.GetActiveScene().name == "Game_Level3")
            {

                if (spawnEnemy == true)
                {

                    Level3EnemySpawn();
                }

                stopcameracontroller();
            }
        
    }

    void Level2EnemySpawn()
    {
        Transform camTransform = gameObject.GetComponent<Transform>();

        if (camTransform.position.x >= 15f && camTransform.position.x <= 134f)
        {
            _spawnEnenyScript.enabled = true;
        }
        else if (camTransform.position.x >= 135f && camTransform.position.x <= 265f)
        {
            _spawnEnenyScript.enabled = false;
        }
        else if (camTransform.position.x >= 278f && camTransform.position.x <= 409f)
        {
            _spawnEnenyScript.enabled = true;
        }
        else if (camTransform.position.x >= 410f && camTransform.position.x <= 485f)
        {
            _spawnEnenyScript.enabled = false;
        }
        else if (camTransform.position.x >= 663f && camTransform.position.x <= 1007f)
        {
            _spawnEnenyScript.enabled = true;

        }
        else if (camTransform.position.x >= 1008f && camTransform.position.x <= 1079f)
        {
            _spawnEnenyScript.enabled = false;

        }
        else if (camTransform.position.x >= 1100f && camTransform.position.x <= 2558f)
        {
            _spawnEnenyScript.enabled = true;

        }
        else if (camTransform.position.x >= 2534.31f)
        {
            _spawnEnenyScript.enabled = false;
        }
    }

    void Level3EnemySpawn() {

        if (transform.position.x >= 0 && transform.position.x <= 256) {

            _spawnEnenyScript.enabled = true;
        }
    
    }
    void stopcameracontroller()
    {
        Transform camTransform = gameObject.GetComponent<Transform>();

        if (SceneManager.GetActiveScene().name == "Game_Level2") {

            if (transform.position.x >= 485f && transform.position.x <= 486f && trailerview == true)
            {
                movecamerax = false;
            }
            else if (transform.position.x >= 502f && transform.position.x <= 533f)
            {
                changeCamera.enabled = false;
                movecamerax = true;
            }
            else if (transform.position.x >= 533f && transform.position.x <= 1000f && transform.position.y >= 12f && transform.position.y <= 54.4f)
            {
                movecamerax = false;
                movecameray = true;
            }
            else if (transform.position.x >= 270f && transform.position.x <= 300f)
            {
                movecamerax = true;
                movecameray = false;
            }
            else if (transform.position.x >= 533f && transform.position.x <= 1000f && transform.position.y >= 54.5f)
            {
                movecamerax = true;
                movecameray = false;
            }
            else if (transform.position.x >= 1078f && transform.position.x <= 2492f && transform.position.y >= 14.9f && transform.position.y <= 17f)
            {
                changeCamera.enabled = false;
                movecamerax = true;
            }
            else if (transform.position.x >= 2566.8 && transform.position.x <= 3108 && transform.position.y <= 1.1)
            {
                changeCamera.enabled = false;

            }
            else if (transform.position.x >= 3128.66)
            {
                movecamerax = false;
            }
        }

        if (SceneManager.GetActiveScene().name == "Game_Level3") {

            if (camTransform.position.x >= 275 && camTransform.position.y < 136) {
                movecamerax = false;
                movecameray = true;
            }
            else if (camTransform.position.x >= 275 && camTransform.position.y >= 136)
            {
                movecameray = false;
            }
            else if (camTransform.position.x <= 276 && camTransform.position.y >= 136)
            {
                negmovecamerax = true;
            }
            else if (camTransform.position.x <= -53 && camTransform.position.y <= 137 && camTransform.position.y >= 25) {
                negmovecamerax = false;
                negmovecameray = true;
            }
            else if (camTransform.position.x <= -53 && camTransform.position.y <= 26 && camTransform.position.y >= 11)
            {
                movecamerax = true;
                negmovecameray = false;
            }
            else if (camTransform.position.x >= 226 && camTransform.position.y >=11 && camTransform.position.y <= 26) {
                movecamerax = false;
                movecameray = true;
            }
            else if (camTransform.position.x >= 226 && camTransform.position.x <= 248 && camTransform.position.y >= 54) {
                movecameray = false;
                negmovecamerax = true;
            }
            else if (camTransform.position.x <= 6 && camTransform.position.x >= -27.5 && camTransform.position.y >= 54 && camTransform.position.y <= 81)
            {
                movecameray = true;
                negmovecamerax = false;
            }
            else if (camTransform.position.x <= 6 && camTransform.position.x >= -27 && camTransform.position.y >= 81 && camTransform.position.y <= 83)
            {
                movecameray = false;
                movecamerax = true;
            }
            else if (camTransform.position.x >=92  && camTransform.position.y >= 80)
            {
                movecamerax = false; 
            }

        }
    }

    void TurningOnOffSpawnEnemy() {
        

        if (camTransform.position.x >= vpBetweenTwoPoint.startPoint[currentEnemySpawn].x && camTransform.position.x < vpBetweenTwoPoint.endPoint[currentEnemySpawn].x) {
            _spawnEnenyScript.enabled = true;
            perivousCurrentEnemySpawn = currentEnemySpawn;
            print("Start Point: " + vpBetweenTwoPoint.startPoint[currentEnemySpawn].x);
            print("End Point: " + vpBetweenTwoPoint.endPoint[currentEnemySpawn].x);
            print("Perivous Current Enemy Spawn: " + perivousCurrentEnemySpawn);
        }
        else {
            if (_spawnEnenyScript.enabled == true) {
                currentEnemySpawn++;
                print("Current Enemy Spawn: " + currentEnemySpawn);
            }
            _spawnEnenyScript.enabled = false;
        }
    }
}
