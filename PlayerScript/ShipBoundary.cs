using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBoundary : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public Camera mCamera;

    public int xbound;
    public int xbound2;
    public int ybound;
    public int ybound2;

    
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<MeshRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<MeshRenderer>().bounds.extents.y;
        mCamera = FindObjectOfType<Camera>(); 
    }

    private void LateUpdate()
    {

        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -xbound + (objectWidth * 3.5f) + mCamera.transform.position.x, screenBounds.x * xbound2 - (objectWidth * 3.9f) + mCamera.transform.position.x);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -ybound + (objectHeight * 3.5f) + mCamera.transform.position.y, screenBounds.y * ybound2 - (objectHeight *3.9f) + mCamera.transform.position.y);
        transform.position = viewPos;
    }

    public void ShipBoundryInLevel() {
        xbound = 36;
        xbound2 = 36;
    }

    public void ShipBoundryInBoss() {

        xbound = 33;
        xbound2 = 23;
    }
}
