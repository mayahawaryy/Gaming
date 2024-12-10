using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] GameObject Player;
    public bool picked;
    private Vector2 vel;
    public float SmoothTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {if(picked){
        Vector3 offset=new Vector3(0,1,0);
        transform.position=Vector2.SmoothDamp(transform.position,Player.transform.position + offset, ref vel , SmoothTime);
    }
    }
    private void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.CompareTag("Player")&& !picked){
            picked=true ;
        }
    }
}
