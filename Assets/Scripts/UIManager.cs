using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using modelSpace;
using TMPro;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    
    private GameObject mainpanel;
    private SlideController mainslide;
    private GameObject logpanel;
    private SlideController logslide;
    private GameObject logbutton;

    LocalPlayer PlayerProfile;

    public TMP_Text NamePlate;
    public Text plate;

    ApiManager apiManager = new ApiManager();

    public TMP_InputField password;
    public TMP_InputField mail;

    public UserData MainPlayer;
    LoginData ld;


    public NetworkManager networkManager;

   void Awake()
    {

        //Mechanical stuff that positions the home screen properly
        mainpanel = GameObject.Find("MainPanel");
        mainslide = mainpanel.GetComponent<SlideController>();
        mainslide.time = 0.005f;
        mainslide.SlideInFlag();
        //-------------------------

        logbutton = GameObject.Find("LogInButton");

        //Create Empty Player Profile
        PlayerProfile = new LocalPlayer();

       



    }

    void Start()
    {
        //Position Login Screen properly
        logpanel = GameObject.Find("LogIn");
        logslide = logpanel.GetComponent<SlideController>();



        plate.GetComponent<Text>().text = "BlahBlah";





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
        
    
        StartCoroutine(Login());




    }

    public IEnumerator Login()
    {
        string email = mail.text;
        string pass = password.text;

        CoroutineWithData cd = new CoroutineWithData(this, apiManager.LoginUser(email, pass));
        yield return cd.coroutine;

        ld = (LoginData)cd.result;



        PlayerProfile.Name = ld.data.name;
        PlayerProfile.Email = ld.data.email;

        plate.GetComponent<Text>().text = PlayerProfile.Name;

        
        logbutton.SetActive(false);


        MainPlayer.email = ld.data.email;


        mainslide.SlideInFlag();
        logslide.SlideOutFlag();


        Debug.Log("result is " + ld.data.name);

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
