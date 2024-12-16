using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] GameObject Player1;
    [SerializeField] GameObject Player2;

    public bool picked;
    private Vector2 vel;
    public float SmoothTime;
    public AudioClip keycollected; // Ensure this is assigned in the Inspector
    private int playerIndex = -1; // Track which player picked it up

    // Start is called before the first frame update
    void Start()
    {
        // Validate that the AudioManager is present
        if (AudioManager.instance == null)
        {
            Debug.LogError("AudioManager instance is not found in the scene!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (picked)
        {
            // Play the sound when the key is picked
            if (keycollected != null && AudioManager.instance != null)
            {
                AudioManager.instance.PlaySingle(keycollected); // Call a standard play method instead of randomizing
                keycollected = null; // Prevent the audio from replaying
            }

            // Smooth follow logic
            Vector3 offset = new Vector3(0, 1, 0);
            Vector3 targetPosition;

            if (playerIndex == 0) 
            {
                targetPosition = Player1.transform.position + offset;
            }
            else if (playerIndex == 1) 
            {
                targetPosition = Player2.transform.position + offset;
            }
            else 
            {
                Debug.LogError("Invalid player index!");
                return; 
            }

            transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref vel, SmoothTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!picked)
        {
            if (other.gameObject == Player1)
            {
                picked = true;
                playerIndex = 0; 
            }
            else if (other.gameObject == Player2)
            {
                picked = true;
                playerIndex = 1; 
            }
        }
    }
}
