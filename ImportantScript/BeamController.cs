using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    public int score;
    public EnemyAI enemyai;
    public BuffDropRate enemyBuffDropRate;
    public MeshRenderer enemyMeshRend;
    public MeshCollider enemyCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out EnemyAI enemyai))
        {
            enemyBuffDropRate = other.GetComponentInParent<BuffDropRate>();
            enemyMeshRend = other.GetComponent<MeshRenderer>();
            enemyCollider = other.GetComponent<MeshCollider>();

            if (enemyai.enabled == true)
            {
                enemyai.hp -= 10;
                
            }

            if (enemyai.hp <= 0)
            {

                enemyBuffDropRate.Dropbuff();
                //enemyai.ExplosionGoBoom();
                //enemyai.score(score);
                enemyMeshRend.enabled = false;
                enemyCollider.enabled = false;
                Destroy(other.gameObject, .5f);
            }

        }

    }
}
