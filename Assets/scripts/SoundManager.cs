using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource doornt; 
    public AudioSource fallDeath; 
    public AudioSource footStep; 
    public AudioSource gameOver;
    public AudioSource hit;
    public AudioSource jump;
    public AudioSource pickKey;
    public AudioSource pullFx;
    public AudioSource doorEnter;
    public AudioSource spaceGo; 

    void Start() {
        doornt = GameObject.Find ("Doorn't").GetComponent<AudioSource> ();
        fallDeath = GameObject.Find ("FDeath").GetComponent<AudioSource> ();
        footStep = GameObject.Find ("FootStep").GetComponent<AudioSource> ();
        gameOver = GameObject.Find ("GameOver").GetComponent<AudioSource> ();
        hit = GameObject.Find ("Hit").GetComponent<AudioSource> ();
        jump = GameObject.Find ("Jump").GetComponent<AudioSource> ();
        pickKey = GameObject.Find ("PickKey").GetComponent<AudioSource> ();
        pullFx = GameObject.Find ("PullFx").GetComponent<AudioSource> ();
        doorEnter = GameObject.Find ("DoorEnter").GetComponent<AudioSource> ();
        spaceGo = GameObject.Find ("SpaceToGo").GetComponent<AudioSource> ();
    }     

    public void soundFx(AudioSource fx){
        fx.Play();
    } 
    
    public void sfManager(string audioName){
        switch (audioName)
        {
              case "Door":
                soundFx(doornt);
                break;

              case "Fall":
                soundFx(fallDeath);
                break;
              
              case "Move":
                soundFx(footStep);
                break;

              case "GameOver":
                soundFx(gameOver);
                break;

              case "Hit":
                soundFx(hit);
                break;

              case "Jump":
                soundFx(jump);
                break;

              case "Key":
                soundFx(pickKey);
                break;

              case "Pull":
                soundFx(pullFx);
                break;

              case "DoorEnter":
                soundFx(doorEnter);
                break;

              case "Space":
                soundFx(spaceGo);
                break; 
              default:
                break;
        }
        
    }

}
