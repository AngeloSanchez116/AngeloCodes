using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryBullet : MonoBehaviour , IDestroyObjects
{
    public int score;
    public GameObject boom;
    public Rigidbody bullerrb;
    public MeshRenderer bulletMeshRend;
    public CapsuleCollider bulletCap;

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
        bullerrb = GetComponent<Rigidbody>();
        bulletMeshRend = GetComponent<MeshRenderer>();
        bulletCap = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        Destroy(gameObject,5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Level")) {

            DestoryObjets();
        }

        if (other.gameObject.TryGetComponent(out EnemyAI enemyAi))
        {
                bullerrb.velocity = new Vector3(0f, 0f, 0f);

                if (enemyAi.enabled == true) {
                    enemyAi.hp -= 1;
                }
                if (enemyAi.hp <= 0) {

                   enemyAi.DestoryEnemy();
                }

                boom.SetActive(true);
                bulletMeshRend.enabled = false;
                bulletCap.enabled = false;
                Destroy(gameObject, .5f);
            
        }
        else if (gameObject.name == "Enemy_Bullet" && other.gameObject.TryGetComponent(out ShipDestuctions shipDestuctions)) {

            shipDestuctions.DestoryObjets();
        }
        else if (other.CompareTag("Shootable"))
        {
            DestoryObjets();

        }
    }

    public void DestoryObjets()
    {
        bullerrb.velocity = new Vector3(0f, 0f, 0f);
        bulletMeshRend.enabled = false;
        bulletCap.enabled = false;
        boom.SetActive(true);
        Destroy(gameObject, .1f);
    }

    public void DestroyObjectsWithTimer()
    {
    }
}
