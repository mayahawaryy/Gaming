using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneController.instance.NextLevel();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
