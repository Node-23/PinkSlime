using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
   public int sceneWanted;
    void Awake() {
    DontDestroyOnLoad(gameObject);   
    }

    void Update() {
        if(SceneManager.GetActiveScene().buildIndex>=sceneWanted){
            Destroy(gameObject);
        }
    }

}
