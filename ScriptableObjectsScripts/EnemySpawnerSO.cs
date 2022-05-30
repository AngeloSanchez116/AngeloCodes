using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawner", menuName = "ScriptableObject/EnemySpawner", order = 1)]
public class EnemySpawnerSO : ScriptableObject
{
    public List<GameObject> enemy;
    public List<Vector3> SpawnLoc;
}
