using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool RedBlock;
    public bool BlueBlock;
    public Text keyNumber;
    public Text SceneName;
    public player player;
    public Animator fadeUp;
    public Animator fadeDown;
    void Start()
    {
        fadeUp = GameObject.Find ("FadeUp").GetComponent<Animator> ();
        fadeDown = GameObject.Find ("FadeDown").GetComponent<Animator> ();
        player = GameObject.Find ("Player").GetComponent<player> ();
        keyNumber = GameObject.Find ("KeyNumber").GetComponent<Text>();
        SceneName = GameObject.Find ("SceneName").GetComponent<Text>();
        SceneName.text = SceneManager.GetActiveScene().name;
    }

    void Update() {
        keyNumber.text = "X"+player.KACount;
        anim();
    }
    public void rb(){
        RedBlock = !RedBlock;
    }

    public void bb(){
        BlueBlock = !BlueBlock;
    }

    public void anim(){
        if(player.dead){
            fadeUp.SetBool("End",true);
            fadeDown.SetBool("End",true);
            StartCoroutine("reload");
        }
    }
    public void nextLevel(){
        StartCoroutine("nextLevelEnum");
    }

    IEnumerator reload(){
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator nextLevelEnum(){
        player.controlOn = false;
        player.door = true;
        fadeUp.SetBool("End",true);
        fadeDown.SetBool("End",true);
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}