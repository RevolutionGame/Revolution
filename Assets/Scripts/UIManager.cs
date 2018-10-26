using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public GameObject mainpanel;
    private SlideController mainslide;

    //public GameObject secondpanel;
    //private SlideController secondslide;



    public void DisableBoolAnimator(Animator anim)
    {
        anim.SetBool("IsDisplayed", false);
    }

    public void EnableBoolAnimator(Animator anim)
    {
        anim.SetBool("IsDisplayed", true);
    }

    void Awake()
    {
        mainslide = mainpanel.GetComponent<SlideController>();
        mainslide.time = 0.005f;
        mainslide.SlideInFlag();
    }

    void Start()
    {
        
    }

    public void StartGame(int scene)
    {
        SceneManager.LoadScene(scene);
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
