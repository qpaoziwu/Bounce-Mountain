using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_move : MonoBehaviour
{


    //CurrentIndex is the current destination
    public int currentIndex;

    //originPos stores the spawn point of the gameObject
    public Vector3 originPos;

    //pauseTime is the rest time between each point
    //*Do not edit stopTimer*
    public float pauseTime;
    private float stopTimer;

    // The Movement Speed of the gameObject,
    // lerpTime controls the total travel time between each point
    // Only edit the lerpTime if u know whatsup
    public float moveSpeed;
    private float lerpTime;
    private List<Vector3> points = new List<Vector3>();

    // isMoving is the boolean that triggers all the movement in Move();
    // toggling isMoving stops movements
    public bool isMoving;

    void Start()
    {
        points = GetPoints();
        originPos = points[0];
    }

    void Update()
    {
        Move();
    }


    /////Editor Gizmo
    ///This Gizmo draws lines in the Editor/Scene window
    private void OnDrawGizmos()
    {
        List<Vector3> points = this.points;

        /// This function allow gizmo to read the points even not in play mode
        if (!Application.isPlaying)
        {
            points = GetPoints();
        }

        for (int i = 0; i < points.Count; i++)
        {
            if (i == points.Count - 1)
            {
                Gizmos.DrawLine(points[i], points[0]);
            }
            else
            {
                Gizmos.DrawLine(points[i], points[i + 1]);
            }
        }
    }


    /////GetPoints 
    ///This function grabs all child objects contains the keyword "waypoint",
    ///returns all the point in List<Vector3> points, then destroy those objects
    private List<Vector3> GetPoints()
    {
        List<Vector3> points = new List<Vector3>();

        Transform[] possibleDestinations = GetComponentsInChildren<Transform>();
        
        ///This loop reads through all the child objects
        foreach (Transform child in possibleDestinations)
        {
            if (child.name.Contains("waypoint"))
            {
                points.Add(child.position);

                ///Destroy childObjects on play
                if (Application.isPlaying)
                {
                    Destroy(child.gameObject);
                }
            }
        }

        return points;
    }


    //Move function that moves the gameObject attached to it
    void Move()

    {
        // isMoving is the boolean that triggers the whole movement
        // toggling isMoving stops movements
        if (isMoving)
        {
            //moving points
            Vector3 a = points[currentIndex];
            Vector3 b = Vector3.zero;

            //if point reaches the end of the list
            if (points.Count <= currentIndex + 1)
            {
                b = points[0];
            }
            else
            {
                b = points[currentIndex + 1];
            }

            //When the lerp time reaches the end, idex increases
            if (lerpTime >= 1f)
            {
                currentIndex++;
                lerpTime = 0f;

                isMoving = false;

                if (currentIndex >= points.Count)
                {
             // When index is above list length reset to 0
                    currentIndex = 0;
                }
                return;
            }

            //Averaging the speed throughout the distance
            float distanceMultiplier = Vector3.Distance(a, b);
            lerpTime += Time.deltaTime * moveSpeed / distanceMultiplier;

            //Moving function
            transform.position = Vector3.Lerp(a, b, lerpTime);

        }

        if (!isMoving)
        {
            //Stop Timer
            stopTimer = stopTimer - Time.deltaTime;
            if (stopTimer < 0)
            { 
                stopTimer = pauseTime;
                isMoving = true;
            }
        }

    }

}
