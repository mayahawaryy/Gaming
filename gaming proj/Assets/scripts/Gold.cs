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
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {


    }
    void OnTriggerEnter2D(Collider2D other)

{
       if(other.gameObject.CompareTag("Player"))
{
// Change the Block sprite
sr.sprite = explodedBlock;
SceneManager.LoadScene(7);
//Destroy(gameObject, .2f);
}
}
}