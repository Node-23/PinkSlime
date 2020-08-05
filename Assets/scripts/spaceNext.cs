using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class spaceNext : MonoBehaviour
{
    public Keys keys;
    public Animator fadeUp;
    public Animator fadeDown;
    public SoundManager soundManager;
    void Start()
    {
        fadeUp = GameObject.Find ("FadeUp").GetComponent<Animator> ();
        fadeDown = GameObject.Find ("fadeDown").GetComponent<Animator> ();
         soundManager = GameObject.Find ("SoundManager").GetComponent<SoundManager> ();
        keys = GetComponent<Keys>();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(keys.jump)){
            fadeUp.SetBool("On",true);
            fadeDown.SetBool("On",true);
            StartCoroutine("next");
            
        }
    }

    IEnumerator next(){
        soundManager.sfManager("Space");
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
