using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPlayerCamera : MonoBehaviour
{
    public Transform object1;
    public Transform object2;
    public float minSizeY;
    public float screenEdgeOffset;

    void Update()
    {
        SetCameraPosition();
        SetCameraSize();
    }

    void SetCameraPosition()
    {
        //Calculate the midpoint between the two select objects
        Vector3 midPoint = (object1.position + object2.position) * 0.5f;
        gameObject.GetComponent<Camera>().transform.position = 
            new Vector3(midPoint.x, midPoint.y, gameObject.GetComponent<Camera>().transform.position.z);
    }

    void SetCameraSize()
    {
        //The horizontal size is based on screen ratio
        float minSizeX = minSizeY * Screen.width / Screen.height;

        //Ortographic size is half height, so multiply by 0.5
        float cameraWidth = Mathf.Abs(object1.position.x - object2.position.x) * 0.5f;
        float cameraHeight = Mathf.Abs(object1.position.y - object2.position.y) * 0.5f;

        //Calculate camera size, accounting for screen edge offset
        float camSizeX = Mathf.Max(cameraWidth, minSizeX) + screenEdgeOffset;
        gameObject.GetComponent<Camera>().orthographicSize = 
            Mathf.Max(cameraHeight, camSizeX * Screen.height / Screen.width, minSizeY) + screenEdgeOffset;
    }

    
}