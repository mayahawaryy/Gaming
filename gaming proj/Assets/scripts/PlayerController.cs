using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;

    public KeyCode SpaceBar;
    public KeyCode R;
    public KeyCode L;

    public Transform groundCheck;
    public float groundCheckRadius;

    public LayerMask whatIsGround;
    private bool grounded;

    private Animator anim;

    public KeyCode Return;
    public Transform firepoint;
    public GameObject bullet;
    public int totalcoins;
    public AudioClip jump1;
    public AudioClip jump2;

    public AudioClip shooting;
    public bool islookingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Return))
        {
            Shoot();
        }

        if (Input.GetKeyDown(SpaceBar) && grounded)
        {
            Jump();
        }

        if (Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                islookingRight = false;
            }
        }

        if (Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                islookingRight = true;
            }
        }
        anim.SetFloat("speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("ground", grounded);
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        //AudioManager.instance.RandomizeSfx(jump1, jump2);
    }

    public void Shoot()
    {
        Instantiate(bullet, firepoint.position, firepoint.rotation);
        //AudioManager.instance.RandomizeSfx(shooting);
    }
}






