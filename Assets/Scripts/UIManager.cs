using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    
    private GameObject mainpanel;
    private SlideController mainslide;
    private GameObject logpanel;
    private SlideController logslide;


    NetworkManager networkManager;
    

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
        mainpanel = GameObject.Find("MainPanel");
        mainslide = mainpanel.GetComponent<SlideController>();
        mainslide.time = 0.005f;
        mainslide.SlideInFlag();

    
        
    }

    void Start()
    {
        logpanel = GameObject.Find("Log");
        logslide = logpanel.GetComponent<SlideController>();

        networkManager = new NetworkManager();

    }

    void Update()
    {
      
    }

    public void StartGame(int scene)
    {
        SceneManager.LoadScene(scene);
        
    }

    public void ExitGame()
    {
        UnityEngine.Application.Quit();
        

    }

    public void login()
    {
        StartCoroutine(networkManager.login());

        if(networkManager.MainPlayer.Email != null)
        {
            mainslide.SlideInFlag();
            logslide.SlideOutFlag();

        }

    }



}
