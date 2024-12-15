using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject pointA; // First GameObject (lower position)
    public GameObject pointB; // Second GameObject (higher position)
    public float speed = 2f;
    public float reachThreshold = 0.1f; // Distance threshold to switch direction

    private bool movingUp = true;

    void Update()
    {
        // Determine the target position (either pointA or pointB)
        Vector2 targetPosition = movingUp ? pointB.transform.position : pointA.transform.position;

        // Move towards the target position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Debugging: Print the positions and direction
        Debug.Log("Current Position: " + transform.position + " Target Position: " + targetPosition);

        // Check if the object has reached the target position within the threshold
        if (Vector2.Distance(transform.position, targetPosition) < reachThreshold)
        {
            // Debugging: Print when the direction switches
            Debug.Log("Switching Direction");

            movingUp = !movingUp; // Toggle movement direction
        }
    }
}
