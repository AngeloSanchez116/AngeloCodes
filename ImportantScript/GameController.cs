using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Core Objects")]
    public GameObject player;
    public GameObject mcamera;
    public static GameController GC = new GameController();

    public PlayerState pState;
    public ShootingControl pShootControl;
    public SpawnEnemy spawnEnemy;

    public int currentlevel;
    private float multi;

    [SerializeField]
    private int nextlevel;

    public static bool inLevel;

    private void Awake()
    {
        GC = this;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mcamera = GameObject.FindGameObjectWithTag("MainCamera");

        if (player != null)
        {
            pShootControl = player.GetComponent<ShootingControl>();
            pState = player.GetComponent<PlayerState>();
        }

        spawnEnemy = mcamera.GetComponentInChildren<SpawnEnemy>();
        currentlevel = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {

            SceneManager.LoadScene(currentlevel);
        }

        if (pState.plives <= 0) {

            SceneManager.LoadScene(currentlevel);
        }

        if (SceneManager.GetActiveScene().buildIndex%2 == 0)
        {
            player.GetComponent<ShipBoundary>().ShipBoundryInBoss();
        }
        else {

            player.GetComponent<ShipBoundary>().ShipBoundryInLevel();
        }

    }

    public void EndDemo() {
        SceneManager.LoadScene(0);
    }

    public void Restartgame() {

        SceneManager.LoadScene(currentlevel);
    }

    public void NextLevel()
    {
        currentlevel = SceneManager.GetActiveScene().buildIndex;
        nextlevel = currentlevel;
        nextlevel +=1;
        currentlevel = nextlevel;
        SceneManager.LoadScene(nextlevel);
    }

    public float RealTimeScaling() {

        if (player != null) {

            switch (pShootControl.buff)
            {

                case 1:
                    spawnEnemy.spawnResetTimer = 0.8f;
                    multi = 1f;
                    break;
                case 2:
                    spawnEnemy.spawnResetTimer = 0.8f;
                    multi = 1.2f;
                    break;
                case 3:
                    spawnEnemy.spawnResetTimer = 0.6f;
                    multi = 1.3f;
                    break;
                case 4:
                    spawnEnemy.spawnResetTimer = 0.5f;
                    multi = 1.4f;
                    break;
            }
            if (pShootControl.buff >= 5)
            {
                spawnEnemy.spawnResetTimer = 0.4f;
                multi = 1.6f;
            }
        }

        return multi;
    }

}
