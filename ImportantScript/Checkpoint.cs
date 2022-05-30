using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public ChecKPointSO checkPoint;

    public GameObject checkPointObj;
    public MeshRenderer checkpointMeshRend;

    public GameObject checkPointUi;
    public Animator checkPointAnim;

    public bool checkpointisactive;
    public bool checkPointUIExist;

    private void Awake()
    {
        if (checkPointObj != null) {
            checkpointMeshRend = checkPointObj.GetComponent<MeshRenderer>();
        }
        if (checkPointUIExist == true) {
            checkPointAnim = checkPointUi.GetComponent<Animator>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            checkPoint.checkpointPosition = other.transform.position;
            checkPoint.camaraCheckpointPosition = GameController.GC.mcamera.transform.position;
            MoveLevel.perivousCurrentEnemySpawn = MoveLevel.currentEnemySpawn;
            if (checkpointisactive == true) {
                checkpointMeshRend.material = checkPoint.checkPointMat;
                StartCoroutine(FlashCheckpointUI());
            }
        }
    }

    IEnumerator FlashCheckpointUI() 
    {
        checkPointUi.SetActive(true);
        checkPointAnim.Play("Checkpoint_UI_Fade");
        yield return new WaitForSeconds(2f);
        checkPointAnim.enabled = false;
        checkPointUi.SetActive(false);
        checkpointisactive = false;
    }
}
