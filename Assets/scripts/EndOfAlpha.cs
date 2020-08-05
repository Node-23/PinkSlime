using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfAlpha : MonoBehaviour
{
    public Keys keys;

    void Start() {
        keys = GetComponent<Keys>();
    }
    void Update()
    {
        if(Input.GetKeyDown(keys.jump)){
            Application.Quit();
        }
    }
}
