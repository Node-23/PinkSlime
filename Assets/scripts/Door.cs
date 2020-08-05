using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
     public player player;
     public Animator animator;
     public BoxCollider2D boxCollider;
     public GameManager gameManager;
    void Start() {
         player = GameObject.Find ("Player").GetComponent<player> ();
         animator = GetComponent<Animator> ();
         boxCollider = GetComponent<BoxCollider2D>();
         gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            next();
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("Player")){
            next();
        }
    }

    public void next(){
        if(player.key&&player.intr){
            Destroy(player.keysArray[player.KACount-1]);
            player.KACount--;
            animator.SetBool("open",true);
            Destroy(boxCollider);
            gameManager.nextLevel();
        } 
    }
}

