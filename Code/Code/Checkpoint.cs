using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private CheckPointSO checkPointSo;
    public GameObject checkPointObj;
    private MeshRenderer checkpointMeshRend;
    [SerializeField]
    private bool firstCheckPoint;

    public delegate void playUIElements();
    public static playUIElements playCheckpointUI;

    [SerializeField]
    private bool checkpointIsActive;
    private Transform camSavePosition;
    private LerpBetweenTwoPoint lerpBetweenTwoPoint;

    private void Awake()
    {
        checkPointSo = FindCheckpointSO();
        camSavePosition = GameObject.FindGameObjectWithTag("MainCamera").transform;

        if (lerpBetweenTwoPoint == null) {
            lerpBetweenTwoPoint = FindObjectOfType<LerpBetweenTwoPoint>();
        }

        checkpointIsActive = true;

        if (checkPointObj != null) {
            checkpointMeshRend = checkPointObj.GetComponent<MeshRenderer>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHitbox"))
        {
            if (checkpointIsActive == true) {
                
                if (checkpointMeshRend.enabled == true) {
                    checkpointMeshRend.material = checkPointSo.checkPointMat;
                }

                checkPointSo.playerCheckpointPosition = other.transform.position;
                checkPointSo.camaraCheckpointPosition = camSavePosition.position;
                if (FindObjectOfType<LerpBetweenTwoPoint>() != null) {
                    checkPointSo.distCovered = lerpBetweenTwoPoint.distCovered;
                    checkPointSo.journeyLength = lerpBetweenTwoPoint.journeyLength;
                    checkPointSo.nextPosition = lerpBetweenTwoPoint.nextPosition;
                }
                if (firstCheckPoint != true) {
                    playCheckpointUI();
                }

                //SpawnEnemy.perivousSboundryListValue = SpawnEnemy.spawnBoundryListValue;

                checkpointIsActive = false;

            }
        }
    }

    private CheckPointSO FindCheckpointSO() {
        checkPointSo =  Resources.Load<CheckPointSO>("Scritable Objects/CheckPoint_SO");
        return checkPointSo;
    }

}
