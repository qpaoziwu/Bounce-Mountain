using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGiraffes : MonoBehaviour
{
    public GameObject giraffePuppet;
    public int maximumGiraffes;
    public float xPositionMin;
    public float xPositionMax;
    public float yPositionMax;
    public float yPositionMin;

    private int giraffesOnScreen;
    private int giraffesToSpawn;
    private GameObject[] giraffes;
    private GameObject[] giraffeBodies;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        giraffes = GameObject.FindGameObjectsWithTag("GiraffeVisual");
        giraffeBodies = GameObject.FindGameObjectsWithTag("GiraffeBody");
        giraffesOnScreen = giraffes.Length;

        giraffesToSpawn = maximumGiraffes - giraffesOnScreen;

        for (int i = 0; i < giraffesToSpawn; i++)
        {
            Vector2 position = new Vector3(Random.Range(xPositionMin, xPositionMax),
                Random.Range(yPositionMin, yPositionMax), 0.0f);

            Instantiate(giraffePuppet, position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        }

        for (int i = 0; i < giraffeBodies.Length; i++)
        {
            if(giraffeBodies[i].transform.position.y < -7.0f)
            {
                Destroy(giraffes[i]);
            }
        }
    }
}
