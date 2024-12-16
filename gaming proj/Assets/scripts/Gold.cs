using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Gold : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite explodedBlock;
    public int nextSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // No need for any logic in Update for this script
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sr.sprite = explodedBlock; // Set the sprite here
            Destroy(gameObject, 0.2f); // Optionally destroy the game object after a short delay
            SceneManager.LoadScene(nextSceneIndex); // Load the next scene
        }
    }
}
