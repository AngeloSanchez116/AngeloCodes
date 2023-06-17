using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using UnityEngine;
using UnityEngine.SceneManagement;

//Use namespaces. It's good practice and helps avoid naming conflicts

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private CheckPointSO checkPointSo;
    public GameObject checkPointObj;
    private MeshRenderer checkpointMeshRend;
    [SerializeField]
    private bool firstCheckPoint;

    //These two lines can be turned into one line | public static Action delegateName;
    // Article -> https://medium.com/unity-coder-corner/unity-the-benefits-of-using-action-delegates-646d49de1abf
    public delegate void playUIElements();
    public static playUIElements playCheckpointUI;

    [SerializeField]
    private bool checkpointIsActive;
    private Transform camSavePosition;
    private LerpBetweenTwoPoint lerpBetweenTwoPoint;

    private void Awake()
    {
        checkPointSo = FindCheckpointSO();
        //You always want to null check any Find statement because they can return null
        //This can also be changed to the more performant `Camera.main` which will always pull the GameObject with the tag "MainCamera"
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
            //No need to have these `==true` in your if statements. `checkpointMeshRend` will return either true or false so you can just do `if(checkpintMeshRend)`
            if (checkpointIsActive == true) {
                //Same with `.enabled` it's a bool so you can don't need a comparison to true or false. For false you would do the following
                /*
                if(checkpointMeshRend.enabled) <- True
                if(!checkpointMeshRend.enabled)<- False
                */
                if (checkpointMeshRend.enabled == true) {
                    checkpointMeshRend.material = checkPointSo.checkPointMat;
                }

                checkPointSo.playerCheckpointPosition = other.transform.position;
                checkPointSo.camaraCheckpointPosition = camSavePosition.position;
                //although you get points for the null check, do not do this. Find a different way to get this done.
                //If you can't think of one, then just know that this is bad until you find a better option with ti
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
