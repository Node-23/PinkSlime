using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class textFollow : MonoBehaviour
{
    public Transform bee;
    public float speed;
    public bool flip;
    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, bee.position, speed*Time.deltaTime);
        
        if(transform.position.x>9.5f && !flip){
            transform.localScale = new Vector3 (-transform.localScale.x,transform.localScale.y,transform.localScale.z);
            flip = !flip;
        }
        if(transform.position.x<-9.6 && flip){
            transform.localScale = new Vector3 (-transform.localScale.x,transform.localScale.y,transform.localScale.z);
            flip = !flip;
        }
    }

}
