using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redPull : MonoBehaviour
{
    public Animator animator;
    public GameManager gameManager;

    
    void Start()
    {
        animator = GetComponent<Animator> ();
        gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
    }

    void Update() {
     animator.SetBool("RB",gameManager.RedBlock);    
    }
    public void rb(){
        gameManager.rb();   
    }
}
