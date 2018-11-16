using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using modelSpace;

public class UIManager : MonoBehaviour
{
    
    private GameObject mainpanel;
    private SlideController mainslide;
    private GameObject logpanel;
    private SlideController logslide;


    public NetworkManager networkManager;

   void Awake()
    {
        mainpanel = GameObject.Find("MainPanel");
        mainslide = mainpanel.GetComponent<SlideController>();
        mainslide.time = 0.005f;
        mainslide.SlideInFlag();
        
    }

    void Start()
    {
        logpanel = GameObject.Find("LogIn");
        logslide = logpanel.GetComponent<SlideController>();

        

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
        LoginData ld = networkManager.Login();

        if(networkManager.MainPlayer.Email != null)
        {
            mainslide.SlideInFlag();
            logslide.SlideOutFlag();

            Debug.Log("result is succesful: " + ld.data.email);
        }

    }

    #region random methods
    public void DisableBoolAnimator(Animator anim)
    {
        anim.SetBool("IsDisplayed", false);
    }

    public void EnableBoolAnimator(Animator anim)
    {
        anim.SetBool("IsDisplayed", true);

    }
    #endregion

}
