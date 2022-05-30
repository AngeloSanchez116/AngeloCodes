using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffeffect : MonoBehaviour
{
    [SerializeField]
    private SpawnEnemy enemySpawn;

    [SerializeField]
    private UIController UI;

    public ShootingControl shootingController;
    public EnemyAI enemyAi;

    public int Buff_State;
    private void Update()
    { 
       Destroy(gameObject,15f);
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.TryGetComponent(out ShootingControl ShootControl))
       {
            
           if (string.Equals(name, "Buff_Beam(Clone)")) 
           {
                
           }
       }
    }
}
