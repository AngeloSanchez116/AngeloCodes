using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCameraChange : MonoBehaviour
{
    [SerializeField]
    private ChangeCamera changeCam;
    [SerializeField]
    private ShipBoundary shipBound;
    [SerializeField]
    private MoveLevel movelvl;
    [SerializeField]
    private SpawnEnemy spawnEneny;

    private void Start()
    {
        changeCam = FindObjectOfType<ChangeCamera>();
        shipBound = FindObjectOfType<ShipBoundary>();
        movelvl = FindObjectOfType<MoveLevel>();
        spawnEneny = FindObjectOfType<SpawnEnemy>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {

            if (string.Equals(name, "Change_Camera"))
            {
                changeCam.newpostion = new Vector3(0f, 0f, 31.5f);
                changeCam.Finddistancetravel();
                changeCam.enabled = true;
                
            }

            if (string.Equals(name, "Change_Camera (1)")) {

                changeCam.targetobj = gameObject;
                changeCam.newpostion = new Vector3(0f, 1f, 59.06f);
                changeCam.Finddistancetravel();
                shipBound.xbound = 58;
                shipBound.ybound = 25;
                shipBound.ybound2 = 25;
                changeCam.enabled = true;
                gameObject.GetComponent<BoxCollider>().enabled = false;
                
            }

            if (string.Equals(name, "Change_Camera (2)"))
            {

                changeCam.targetobj = gameObject;
                changeCam.newpostion = new Vector3(0f, 0f, 29.08f);
                changeCam.Finddistancetravel();
                shipBound.xbound = 32;
                shipBound.ybound = 14;
                shipBound.ybound2 = 15;
                changeCam.enabled = true;
                
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            movelvl.movecamerax = true;
            spawnEneny.enabled = false;
        }
    }
}
