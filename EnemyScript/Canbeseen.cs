using UnityEngine;

public class Canbeseen : MonoBehaviour
{
    [SerializeField]
    private EnemyAI enemyAi;
    [SerializeField]
    private float turnOnEnemyTimer;
    public float timer;
    private void Start()
    {
        enemyAi = GetComponent<EnemyAI>();
        turnOnEnemyTimer = enemyAi.enemyTemple.turnOnAi;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > turnOnEnemyTimer) {

            TurnOnEnemyAi();
        }
    }

    public void TurnOnEnemyAi() {
        enemyAi.enabled = true;
    }

    public void TurnOffEnemyAi()
    {
        enemyAi.enabled = false;
    }

}
