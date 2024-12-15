using UnityEngine;

public class MovingPlatform2 : MonoBehaviour
{
    public GameObject pointA; // First GameObject (left position)
    public GameObject pointB; // Second GameObject (right position)
    public float speed = 2f;

    private bool movingRight = true;

    void Update()
    {
        // Move between the positions of pointA and pointB
        Vector2 targetPosition = movingRight ? pointB.transform.position : pointA.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the object has reached one of the points
        if ((Vector2)transform.position == targetPosition)
        {
            movingRight = !movingRight; // Toggle movement direction
        }
    }
}
