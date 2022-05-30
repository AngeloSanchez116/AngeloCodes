using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealthBarUIScript : MonoBehaviour
{
    public EnemyAI enemyai;
    public Slider healthbar;

    void Start()
    {
        healthbar = GetComponent<Slider>();
        enemyai = FindObjectOfType<EnemyAI>();
        healthbar.maxValue = enemyai.hp;
        healthbar.value = enemyai.hp;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.value = enemyai.hp;
    }
}
