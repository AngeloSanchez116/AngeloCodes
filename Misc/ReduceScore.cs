using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceScore : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out DestoryBullet bullet)) {

            bullet.DestoryObjets();
        }
        if (other.gameObject.TryGetComponent(out EnemyAI enemyAi)) 
        {
            ScoreReduction(enemyAi.reduceScore);
            enemyAi.DestoryObjets();
        }
    }

    //Reducing player Score
    public void ScoreReduction(int reduceScore)
    {
        if (UIController.uiController.pscore <= 0)
        {
            UIController.uiController.pscore = 0;
        }
        else
        {
            UIController.uiController.pscore -= reduceScore;
        }
    }
}
