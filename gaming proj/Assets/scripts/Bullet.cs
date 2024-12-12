
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float timeremaining;
    // Start is called before the first frame update
    void Start()
    {
       Move player;
        player= FindObjectOfType<Move>();
      
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent <Rigidbody2D>().velocity= new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        if(timeremaining>0){
            timeremaining-=Time.deltaTime;
        }
        else if (timeremaining<=0){
            Destroy(this.gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag=="Enemy"){
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    } 
}