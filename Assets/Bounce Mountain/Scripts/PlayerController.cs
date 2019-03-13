using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Designer-set parameters:")]
    private float increaseForceMultiplier;
    private float reduceForceMultiplier;

    public PlayerData[] playerData = new PlayerData[3];

    public int currentCheckPoint = 0;
    public float lastCheckpointTime = 0;

    private Vector2 mousePosition;

    //Initialize components
    private Rigidbody2D rigidbody2DComponent;
    private LineRenderer lineRendererComponent;
    private AudioSource audioSourceComponent;
    private Launch launchComponent;

    public int objectType;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2DComponent = gameObject.GetComponentInChildren<Rigidbody2D>();
        lineRendererComponent = gameObject.GetComponentInChildren<LineRenderer>();
        launchComponent = gameObject.GetComponentInChildren<Launch>();

        //Disable the line renderer by default
        lineRendererComponent.enabled = false;

        //Assign the first element in the player data array as the default controller values
        increaseForceMultiplier = playerData[0].increaseForceMultiplier;
        reduceForceMultiplier = playerData[0].reduceForceMultiplier;
        gameObject.GetComponent<SpriteRenderer>().color = playerData[0].objectColour;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Ball Type 1"))
        {
            objectType = 0;
        }

        if (Input.GetButtonDown("Ball Type 2"))
        {
            objectType = 1;
        }

        if (Input.GetButtonDown("Ball Type 3"))
        {
            objectType = 2;
        }

        increaseForceMultiplier = playerData[objectType].increaseForceMultiplier;
        reduceForceMultiplier = playerData[objectType].reduceForceMultiplier;
        gameObject.GetComponent<SpriteRenderer>().color = playerData[objectType].objectColour;

        mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        launchComponent.DragToLaunch(mousePosition, increaseForceMultiplier, reduceForceMultiplier, 
            lineRendererComponent, rigidbody2DComponent);
    }
}
