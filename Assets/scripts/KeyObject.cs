using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyObject : MonoBehaviour
{
    public Transform kp;
    public GameObject player;
    public player plr;
    public SoundManager soundManager;
    
    void Start() {
        kp = GameObject.Find ("KeyLocation").GetComponent<Transform> ();
        player = GameObject.Find ("Player");
        plr =  GameObject.Find ("Player").GetComponent<player> ();
        soundManager = GameObject.Find ("SoundManager").GetComponent<SoundManager> ();
    }
     void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
           soundManager.sfManager("Key");
           transform.localPosition = new Vector3(kp.position.x,kp.position.y, 0);
           gameObject.transform.SetParent(player.transform);
           plr.key = true;
           plr.keysArray[plr.KACount] = gameObject;
           plr.KACount++;
        }
    }
}

