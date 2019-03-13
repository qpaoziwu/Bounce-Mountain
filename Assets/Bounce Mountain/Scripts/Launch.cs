using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    private Vector2 mouseClickedPosition;

    // Start is called before the first frame update
    public void DragToLaunch(Vector2 mousePosition, float increaseForceMultiplier, float reduceForceMultiplier,
        LineRenderer lineRendererComponent, Rigidbody2D rigidbody2DComponent)
    {
        Vector2 mouseReleasedPosition;
        Vector2 direction;
        float distance;
        Vector3[] linePoints = new Vector3[2];

        //When the left mouse buttons is clicked, store the current position of the mouse and enable the line renderer
        if (Input.GetMouseButtonDown(0) == true)
        {
            mouseClickedPosition = mousePosition;
            lineRendererComponent.enabled = true;
        }

        //While the left mouse button is held down, reduce the horizontal velocity of the object
        if (Input.GetMouseButton(0) == true)
        {
            rigidbody2DComponent.velocity =
                new Vector2(rigidbody2DComponent.velocity.x - (rigidbody2DComponent.velocity.x * reduceForceMultiplier),
                rigidbody2DComponent.velocity.y);
        }

        //When the left mouse button is released, store the current position of the mouse, calculate the direction and
        //distance from the position where the mouse was clicked to the position of where the mouse was released and
        //apply this force multiplied by the set increase force multiplier. Disable the line renderer.
        if (Input.GetMouseButtonUp(0) == true)
        {
            mouseReleasedPosition = mousePosition;
            direction = mouseClickedPosition - mouseReleasedPosition;
            direction.Normalize();
            distance = Vector2.Distance(mouseClickedPosition, mouseReleasedPosition);
            rigidbody2DComponent.AddForce(direction * distance * increaseForceMultiplier, ForceMode2D.Impulse);
            lineRendererComponent.enabled = false;
        }

        //Render a line that represents the trajectory path of the physics object
        linePoints[0] = new Vector3(rigidbody2DComponent.position.x, rigidbody2DComponent.position.y, 0.0f);
        linePoints[1] = new Vector3(rigidbody2DComponent.position.x + (mouseClickedPosition.x - mousePosition.x),
            rigidbody2DComponent.position.y + (mouseClickedPosition.y - mousePosition.y));
        lineRendererComponent.widthMultiplier = 0.1f;
        lineRendererComponent.SetPositions(linePoints);        
    }
}
