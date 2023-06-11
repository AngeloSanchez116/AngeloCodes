using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpBetweenTwoPoint : MonoBehaviour
{
    
    public float speed = 1.0F;
    public float distCovered;
    public float journeyLength;
    public int nextPosition = 0;
    public GameObject secondPath;

    private Vector3 startMarker;
    private float startTime = 0f;
    [SerializeField]
    private bool startlerp = false;
    private Transform camTransform;

    public List<Transform> endMarker;

    void Start()
    {
        //startTime = Time.time;
        camTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Update()
    {
        //start the lerp
        if (startlerp == true)
        {
            //Makes sure the next position doesnt value doesnt exced the value of the list
            if (nextPosition < endMarker.Count) {
                distCovered += (Time.deltaTime - startTime) * speed;// the speed at which it travels
                float fractionOfJourney = distCovered / journeyLength; // figure out how far along is the object traveled
                camTransform.position = Vector3.Lerp(startMarker, endMarker[nextPosition].position, fractionOfJourney); // the lerp

                //add one more to nextposition value
                if (distCovered >= journeyLength) {
                    nextPosition++;
                    setuplerp();
                }
            }
        }
    }
    //Check if it collide with the player
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHitbox"))
        {
            setuplerp();
        }
    }
    //Sets up the Lerp 
    private void setuplerp() {

        if (secondPath != null)
        {
            secondPath.SetActive(false);
            GetComponent<BoxCollider>().enabled = false;
        }
        else { 
        
        }

        startMarker = camTransform.position;

        if (nextPosition < endMarker.Count) {
            journeyLength = Vector3.Distance(startMarker, endMarker[nextPosition].position);
            distCovered = 0;
        }

        startlerp = true;
    }
}
