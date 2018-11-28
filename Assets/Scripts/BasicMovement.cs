using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {

    public float speed;
    public float jump;
    public float groundRadius;
    public bool grounded;
    public bool grounded2;
    public Transform groundCheck;
    public Transform groundCheck2;
    public LayerMask ground;
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
{  
        if(grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(1f, 1f, .1f);
            anim.SetBool("Walking", true);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(-1f, 1f, .1f);
            anim.SetBool("Walking", true);
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if(!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("Walking", false);
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, ground);
        grounded2 = Physics2D.OverlapCircle(groundCheck2.position, groundRadius, ground);

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded || Input.GetKeyDown(KeyCode.Space) && grounded2)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
        }
        
        if(!grounded && !grounded2)
        {
            anim.SetBool("Jump", true);
        }
        else { anim.SetBool("Jump", false); }
         

    }
}
