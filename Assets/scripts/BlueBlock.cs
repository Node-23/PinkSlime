using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlock : MonoBehaviour
{

    public bool bb;
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
        bb = gameManager.BlueBlock;
        animator.SetBool("BB",bb);
        if(bb){
            boxCollider.isTrigger = false;
            gameObject.layer = 8;
        }else{
            boxCollider.isTrigger = true;
            gameObject.layer = 0;
        }
       
    }
}
