using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Door : MonoBehaviour
{
    public bool locked;
    private Animator a;
    // Start is called before the first frame update
    void Start()
    {
        a=GetComponent<Animator>();
       locked=true ;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Key")){
locked=false;
a.SetTrigger("Open");
SceneManager.LoadScene(5);
//door code edit
}
    }
//
}