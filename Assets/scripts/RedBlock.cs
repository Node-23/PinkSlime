using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBlock : MonoBehaviour
{
    public bool rb;
    public Animator animator;
    public GameManager gameManager;
    public BoxCollider2D boxCollider;
    
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator> ();
        gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
    }
    void Update()
    {
        rb = gameManager.RedBlock;
        animator.SetBool("RB",rb);
        if(rb){
            boxCollider.isTrigger = false;
            gameObject.layer = 8;
        }else{
            boxCollider.isTrigger = true;
            gameObject.layer = 0;
        }
       
    }
   
}
