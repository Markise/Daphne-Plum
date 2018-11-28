using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRolling : MonoBehaviour {


    public float speed;
    public float jumpHeight;
    public Sprite Head;
    private Rigidbody rb;

    Animator anim;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("Moving",true);
            rb.isKinematic = false;
            transform.localScale = new Vector3(1f, 1f, 1f);
            rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("Moving", true);
            rb.isKinematic = false;
            transform.localScale = new Vector3(1f, 1f, 1f);
            rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
        }
	}
}
