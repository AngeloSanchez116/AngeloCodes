using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_ScoreIncrease : MonoBehaviour ,IBuffEffect, IDestroyObjects
{
    public int score;

    private void OnEnable()
    {
        DestroyGamesObjects.ClearedAllGameObjs += DestoryObjets;
    }
    private void OnDisable()
    {
        DestroyGamesObjects.ClearedAllGameObjs -= DestoryObjets;
    }

    private void Update()
    {
        DestroyObjectsWithTimer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {

            BuffEffect();
        }
    }

    public void BuffEffect()
    {
        UIController.uiController.pscore += score;
        DestoryObjets();
    }


    public void DestoryObjets()
    {
        Destroy(gameObject);
    }
    public void DestroyObjectsWithTimer()
    {
        Destroy(gameObject, 15f);
    }
}
