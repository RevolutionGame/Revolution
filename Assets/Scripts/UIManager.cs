using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using modelSpace;
using TMPro;


public class UIManager : MonoBehaviour
{
    
    private GameObject mainpanel;
    private SlideController mainslide;
    private GameObject logpanel;
    private SlideController logslide;
    LocalPlayer PlayerProfile;

    public TMP_Text NamePlate;
    public GameObject plate;

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


        //Create Empty Player Profile
        PlayerProfile = new LocalPlayer();

        
        
    }

    void Start()
    {
        //Position Login Screen properly
        logpanel = GameObject.Find("LogIn");
        logslide = logpanel.GetComponent<SlideController>();


        plate.GetComponent<UnityEngine.UI.Text>().text = "BlahBlah";
        NamePlate = GetComponent<TMP_Text>();





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

        PlayerProfile.Name= ld.data.name;
        PlayerProfile.Email = ld.data.email;

        NamePlate.text = PlayerProfile.Name;



    }

    public void GoogleLogin()
    {
        LoginData ld = networkManager.Login();

        if (networkManager.MainPlayer.Email != null)
        {
            mainslide.SlideInFlag();
            logslide.SlideOutFlag();



            Debug.Log("result is succesful: " + ld.data.email);
        }

        PlayerProfile.Name = ld.data.name;
        PlayerProfile.Email = ld.data.email;

        NamePlate.text = PlayerProfile.Name;



    }

    public void 

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
