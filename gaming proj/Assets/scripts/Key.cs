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

    private int playerIndex = -1; // Track which player picked it up

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (picked)
        {
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