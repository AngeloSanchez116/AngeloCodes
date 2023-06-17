using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//use a namespace
public class LerpBetweenTwoPoint : MonoBehaviour
{
    
    //lowercase `f`
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
        //use Camera.main.transform
        camTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Update()
    {
        //start the lerp
        if (startlerp == true)
        {
            //Look up different examples of Lerp. I see what you are doing but this is a confusing way to do it.
            //You shouldn't be increasing "speed"
            /*
             A LERP is takes in two values and gives you the proportion between them based on a normalized value
            I know that sounds confusing but imagine the start is 0 and the end is 10. You give LERP a "step" which is a value between 0 and 1
            0 = the starting value, 1 = the end value | so Lerp(startingValue, endValue, step);
            Lerp(0, 10, 0.5) = 5
            Lerp(0, 10, 0) = 0
            Lerp(0, 10, 1) = 10
            So don't look at the step as a speed, it is a normalized value between 0 and 1 that returns the proportion of the start and end number
            */

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
        //good null check
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
