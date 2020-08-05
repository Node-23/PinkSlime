using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bluePull : MonoBehaviour
{
    public Animator animator;
    public GameManager gameManager;

    void Start()
    {
        animator = GetComponent<Animator> ();
        gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
    }

    
    void Update()
    {
        animator.SetBool("BB",gameManager.BlueBlock); 
    }
    public void bb(){
        gameManager.bb();   
    }
}
