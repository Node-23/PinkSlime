using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Keys keys;
    private bool movefc;
    public bool key;
    public bool intr;
    public bool dead;
    public bool door;
    public bool ladderforce;
    public bool jumping;
    public bool grounded;
    public bool facingRight;
    public bool ladderBool;
    public bool controlOn = true;
    public int jumpForce;
    public int KACount;
    public float gravity;
    public float speed = 5f;
    private float move;
    public Rigidbody2D rb;
    public Animator animator;
    public Transform groundCheck;
    public SpriteRenderer sr;
    public SoundManager soundManager;
    public GameObject[] keysArray =  new GameObject[5];
    void Start()
    {
        keys = GameObject.Find ("GameManager").GetComponent<Keys> ();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        soundManager = GameObject.Find ("SoundManager").GetComponent<SoundManager> ();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position,groundCheck.position, 1<< LayerMask.NameToLayer("Ground"));
        if(grounded && rb.velocity.y <1f){
           jumping = false;
        }

        if(KACount ==0){
            key = false;
        }
    }
  
    void FixedUpdate()
    {
        movement();
        flip();
        anim();
        jump();
        ladder();  
    }

    public void movement(){
        if(controlOn && Input.GetKey(keys.left)){
            if(!movefc && !jumping){
              movefc = true;
              soundManager.sfManager("Move");    
              StartCoroutine("moveFx");
            }
            move = -1f;
        }else if(controlOn && Input.GetKey(keys.right)){
            if(!movefc && !jumping){
                movefc = true;
                soundManager.sfManager("Move");    
             StartCoroutine("moveFx");
            }
            move = 1f;
        }else{
            move = 0f;
        }
        rb.velocity = new Vector2(move*speed,rb.velocity.y);
    }

    public void flip(){
        if(move<0f && facingRight|| move>0f && !facingRight){
			facingRight = !facingRight;
            sr.flipX = !facingRight;
		}
    }

    public void anim(){
        animator.SetBool("jumping",jumping);
        animator.SetBool("carrying",key);
        animator.SetBool("Dead",dead);
        animator.SetBool("Door",door);
    }

    public void jump(){
        if(Input.GetKeyDown(keys.jump) && grounded && !jumping && controlOn){
            soundManager.sfManager("Jump");
            rb.AddForce(new Vector2(0f,jumpForce));
            jumping = true;
        }
    }

    public void ladder(){
        if(ladderBool){
            rb.gravityScale = 0f;
            if(!ladderforce){
                rb.velocity = new Vector2(0f,0f);
                ladderforce = true;
            }
        if(controlOn && Input.GetKey(keys.up)){
             rb.velocity = new Vector2(rb.velocity.x,3);
             StartCoroutine("ladderMovement");
        }

        if(controlOn && Input.GetKey(keys.down)){
            if(!grounded){
            rb.velocity = new Vector2(rb.velocity.x,-3);
            StartCoroutine("ladderMovement");
            }
        }
        }else{
            rb.gravityScale = gravity;
            ladderforce = false;
        }
        
    }

    public void death(){
        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        controlOn = false;
        dead = true;
    }

    IEnumerator ladderMovement(){
	yield return new WaitForSeconds(0.1f);
    rb.velocity = new Vector2(0f,0f);
    }
    IEnumerator moveFx(){
        yield return new WaitForSeconds(0.15f);
        movefc = false;
    }
}





