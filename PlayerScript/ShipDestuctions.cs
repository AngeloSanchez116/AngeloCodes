using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipDestuctions : MonoBehaviour , IDestroyObjects
{
    public ChecKPointSO Checkpoint;
    public GameObject expolsion;

    private GameObject mCamera;

    [Header("Player Componets")]
    private MoveLevel pMoveLevel;
    private PlayerMovementControl pMoveControl;
    private ShootingControl pShoot;
    private MeshRenderer pmeshRenderer;
    private MeshCollider pmeshCollider;
    private Rigidbody pRB;
    private PlayerState pState;
    private UIController uiController;

    private BossScript boss;

    private void Awake()
    {
        mCamera = GameObject.FindWithTag("MainCamera");
        pMoveLevel = mCamera.GetComponent<MoveLevel>();

        pMoveControl = GetComponent<PlayerMovementControl>();
        pShoot = GetComponent<ShootingControl>();
        pmeshRenderer = GetComponent<MeshRenderer>();
        pmeshCollider = GetComponent<MeshCollider>();

        pRB = GetComponent<Rigidbody>();
        pState = GetComponent<PlayerState>();
        uiController = FindObjectOfType<UIController>();
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
                StartCoroutine(Death());
        }

        if (collision.gameObject.CompareTag("Level"))
        {
                StartCoroutine(Death());
        }  
    }


    public void DestoryObjets()
    {
        StartCoroutine(Death());
    }

    public void DestroyObjectsWithTimer()
    {

    }

    IEnumerator Death()
    {
        //Stop the camera and player from moveing
        pMoveLevel.movecamerax = false;
        pMoveControl.enabled = false;
        pShoot.enabled = false;
        pmeshRenderer.enabled = false;
        pmeshCollider.enabled = false;
        expolsion.SetActive(true);

        //After half a second start fadeing to black
        yield return new WaitForSeconds(0.5f);
        FadingManger.StartFading();

        //Reset the player,Camera postion. Destory all game objects and reset the level. Apply what the player loses for dying
        yield return new WaitForSeconds(1f);
        if (GameController.inLevel == true)
        {
            DestroyInLevel();
        }
        else {

            DestroyInBoss();
        }
        yield return new WaitForSeconds(1f);
        if (GameController.inLevel != true) {
            boss.AnimationChange();
        }
        MoveLevel.currentEnemySpawn = MoveLevel.perivousCurrentEnemySpawn;
        FadingManger.StopFading();
        pMoveLevel.movecamerax = true;
        pMoveControl.enabled = true;
        pShoot.enabled = true;
        pmeshRenderer.enabled = true;
        pmeshCollider.enabled = true;
    }

    private void DestroyInLevel() {
        DestroyGamesObjects.OnObjectDestroy();
        ResetLevel.ResetLevels();
        transform.position = Checkpoint.checkpointPosition;
        GameController.GC.mcamera.transform.position = Checkpoint.camaraCheckpointPosition;
        pState.plives--;
        uiController.pscore = 0;
        pShoot.buff = 1;
        pRB.velocity = new Vector3(0f, 0f, 0f);
        expolsion.SetActive(false);
    }

    private void DestroyInBoss() {

        transform.position = Checkpoint.checkpointPosition;
        pState.plives--;
        uiController.pscore = 0;
        pShoot.buff = 1;
        pRB.velocity = new Vector3(0f, 0f, 0f);
        expolsion.SetActive(false);
        if (boss == null)
        {
            boss = FindObjectOfType<BossScript>();
        }
        boss.StopAllCoroutines();
        boss.currentstate = BossScript.bossState.Idle;
        boss.hp = boss.enemyTemple.hp;
    }
}
