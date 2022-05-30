using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObject/Enemy", order = 2)]
public class EnemyTemplateSO : ScriptableObject
{
    public string enemyName;
    public GameObject model;
    public int hp;
    public int speed;
    public float speedMuti;
    public int gainScore;
    public int reduceScore;
    public float turnOnAi;
}
