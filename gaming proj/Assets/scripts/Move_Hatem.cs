using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Hatem : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public KeyCode Spacebar; // Not used in this script
    public KeyCode R; 
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    private Animator anim;
    public AudioClip jump1;
    public AudioClip jump2;
    public AudioClip shot;
    public KeyCode Return;
    public Transform fire;
    public GameObject Bullet;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        AudioManager.instance.RandomizeSfx(jump1, jump2);
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Return))
        {
            Shoot();
        }
        if (Input.GetKeyDown(Spacebar))
        {
            Jump();
        }
        // Removed L key input
        if (Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        anim.SetFloat("speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("ground", grounded);
    }

    public void Shoot()
    {
        Instantiate(Bullet, fire.position, fire.rotation);
        AudioManager.instance.PlaySingle(shot);
    }
}