using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{
    public Keys keys;
    public bool interact;
    public bool rb;
    public bool bb;
    public redPull redPull;
    public bluePull bluePull;
    public player player;
    public GameObject Balloon;
    GameObject balloonClone;
    public Transform BalloonP;
    public Animator animator;
    public SoundManager soundManager;
    
     void Start() {
        BalloonP = GameObject.Find ("baloon").GetComponent<Transform> ();
        keys = GameObject.Find ("GameManager").GetComponent<Keys> ();
        redPull = GameObject.Find ("RedPull").GetComponent<redPull> ();
        bluePull = GameObject.Find ("BluePull").GetComponent<bluePull> ();
        player = GameObject.Find ("Player").GetComponent<player> ();
        soundManager = GameObject.Find ("SoundManager").GetComponent<SoundManager> ();
    }
    void Update()
    {
         redblock();
         blueblock();
         inter();
    }

    public void redblock(){
            if(player.controlOn && Input.GetKeyDown(keys.interact) && rb){
            soundManager.sfManager("Pull");
            redPull.rb();
            } 
    }

    public void blueblock(){
            if(player.controlOn && Input.GetKeyDown(keys.interact) && bb){
            soundManager.sfManager("Pull");
            bluePull.bb();
            }
    }
    

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("RedPull")){
            rb = true;
            balloonClone = Instantiate(Balloon,BalloonP.position,Quaternion.identity);
            balloonClone.transform.parent = gameObject.transform;
        }
        if(other.CompareTag("BluePull")){
            bb = true;
            balloonClone = Instantiate(Balloon,BalloonP.position,Quaternion.identity);
            balloonClone.transform.parent = gameObject.transform;
        }  
        if(other.CompareTag("Enemy")){
            gameObject.SetActive(false);
            soundManager.sfManager("GameOver");
            player.death();
        } 
        if(other.CompareTag("Ladder")){
            player.ladderBool = true;
        }
        if(other.CompareTag("Death")){
            gameObject.SetActive(false);
            soundManager.sfManager("GameOver");
            player.death();
        }

        if(other.CompareTag("Door")){
             balloonClone = Instantiate(Balloon,BalloonP.position,Quaternion.identity);
             balloonClone.transform.parent = gameObject.transform;
             interact = true;
             
        }
        
    }

    public void inter(){
        if(player.controlOn && Input.GetKeyDown(keys.interact) && interact){
            if(!player.key){
                soundManager.sfManager("Door");
            }else{
                soundManager.sfManager("DoorEnter");
            }
            player.intr = true;
            StartCoroutine("intrFalse");
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("RedPull") ){
            rb = false;
            Destroy(balloonClone);
        }
        if(other.CompareTag("BluePull")){
            bb = false;
            Destroy(balloonClone);
        }
        if(other.CompareTag("Ladder")){
            player.ladderBool = false;
        }
        if(other.CompareTag("Door")){
            Destroy(balloonClone);
            interact = false;
        }
    }
    IEnumerator intrFalse(){
	    yield return new WaitForSeconds(1f);
        player.intr = false;
    }

}

