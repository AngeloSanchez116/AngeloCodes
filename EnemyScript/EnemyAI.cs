using System.Collections;
using UnityEngine;

public class EnemyAI : FlashAnimation , IDestroyObjects
{
    public EnemyTemplateSO enemyTemple;

    [Header("Enemy Stats")]
    public int hp;

    [Header("Death")]
    public GameObject bigExplosion;

    [Header("GameSetup")]
    public MeshCollider enemyMeshCollider;
    public BuffDropRate buffDropRate;
    public int playerScore;
    public int reduceScore;

    private void OnEnable()
    {
        DestroyGamesObjects.ClearedAllGameObjs += DestoryObjets;
    }
    private void OnDisable()
    {
        DestroyGamesObjects.ClearedAllGameObjs -= DestoryObjets;
    }

    private void Awake()
    {
        hp = enemyTemple.hp;
        playerScore = enemyTemple.gainScore;
        reduceScore = enemyTemple.reduceScore;
        enemyMeshCollider = GetComponent<MeshCollider>();
        buffDropRate = GetComponentInParent<BuffDropRate>();
        
        GetTexture();
        StartCoroutine(PassFlashMaterial());
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.CompareTag("Bullet")) {
                setFlash();
            }
    }

    public void DestoryEnemy() {

        bigExplosion.SetActive(true);

        if (gameObject.tag != "Boss") {

            if (enemyMeshRend != null)
            {
                enemyMeshRend.enabled = false;
            }
            else if (enemyMeshRender != null)
            {
                enemyMeshRender.enabled = false;
            }

            buffDropRate.Dropbuff();
            UIController.uiController.score(playerScore);
            enemyMeshCollider.enabled = false;
            Destroy(transform.parent.gameObject, .5f);
        }
    }

    public void DestoryObjets()
    {
        if (enemyMeshRend != null)
        {
            enemyMeshRend.enabled = false;
        }
        else if (enemyMeshRender != null)
        {

            enemyMeshRender.enabled = false;
        }
        Destroy(transform.parent.gameObject, .5f);
    }

    public void DestroyObjectsWithTimer()
    {
        
    }
}
