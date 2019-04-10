using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardEffect : MonoBehaviour
{
    private Rigidbody2D[] childRigidbody2DComponents;
    private Vector2[] originalPositions = new Vector2[15];

    GameObject parent;
    
    // Start is called before the first frame update
    void Awake()
    {
        parent = transform.parent.gameObject;

        childRigidbody2DComponents = parent.GetComponentsInChildren<Rigidbody2D>();

        for (int i = 0; i < childRigidbody2DComponents.Length; i++)
        {
            originalPositions[i] = childRigidbody2DComponents[i].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetPosition()
    {
        for (int i = 0; i < childRigidbody2DComponents.Length; i++)
        {
            childRigidbody2DComponents[i].position = originalPositions[i];
            childRigidbody2DComponents[i].velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            ResetPosition();
        }
    }
}
