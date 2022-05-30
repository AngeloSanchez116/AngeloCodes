using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_AtkUp : MonoBehaviour,IDestroyObjects
{
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
        if (other.gameObject.TryGetComponent(out ShootingControl ShootControl)) {

            if (ShootControl.buff <= 5)
            {
                ShootControl.buff++;
                DestoryObjets();
            }
        }
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
