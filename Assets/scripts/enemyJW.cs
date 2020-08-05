using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyJW : MonoBehaviour
{
    public bool grounded;
    private bool facingRight;
    public float speed = 3f;
    public Transform groundCheck;
    public Rigidbody2D rb;
    
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position,groundCheck.position, 1<< LayerMask.NameToLayer("Ground"));
        move();
        flip();
    }

    public void move(){
        rb.velocity = new Vector2(speed,rb.velocity.y);
    }

    public void flip(){
        if(!grounded){
            speed = -speed;
            transform.localScale = new Vector3 (-transform.localScale.x,transform.localScale.y,transform.localScale.z);
        }
    }

     void OnTriggerEnter2D(Collider2D other) {
         if(other.CompareTag("Death")){
            Destroy(gameObject);
        }
     }
}
