using UnityEngine;

public class FishMovement: MonoBehaviour
{
    public float speed = 2f;               // Speed at which the fish moves
    public float walkTime = 5f;            // Time interval to switch directions
    public Animator animator;              // Reference to the Animator
    public Transform[] waypoints;          // Array of waypoints for the fish to walk between

    private int currentWaypointIndex = 0;  // Index of current waypoint
    private bool isWalking = true;         // If the fish is walking
    private Rigidbody rb;                  // Reference to Rigidbody for physics-based movement

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        InvokeRepeating("SwitchDirection", 0f, walkTime);  // Call SwitchDirection periodically
    }

    void Update()
    {
        if (isWalking)
        {
            MoveFish();
        }
    }

    void MoveFish()
    {
        // Calculate direction toward the next waypoint
        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;

        // Move the fish towards the waypoint
        Vector3 movement = direction.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);

        // Play the walking animation
        animator.SetBool("isWalking", true);

        // If the fish reaches the waypoint, stop and switch direction
        if (direction.magnitude < 0.1f)
        {
            animator.SetBool("isWalking", false);  // Stop walking animation
            isWalking = false;  // Stop moving temporarily
            Invoke("StartWalking", 1f); // Delay before starting to move again
        }
    }

    void SwitchDirection()
    {
        // Choose a new waypoint randomly (you can adjust how this works)
        currentWaypointIndex = Random.Range(0, waypoints.Length);
    }

    void StartWalking()
    {
        isWalking = true;
    }
}
