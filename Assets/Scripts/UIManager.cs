using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using modelSpace;
using TMPro;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    public GameObject networkManager;
    public Player[] players = new Player[9];


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
    bool Flag = false;



   void Awake()
    {

        //Check if Network Manager Already Exist
        if(NetworkManager.NetworkInstance == null)
        {
            //Create an instance of Network Manager if none exist
            Instantiate(networkManager);

        }


        #region  Mechanical stuff that positions the home screen properly
        mainpanel = GameObject.Find("MainPanel");
        mainslide = mainpanel.GetComponent<SlideController>();
        mainslide.time = 0.005f;
        mainslide.SlideInFlag();

        //Position Login Screen properly
        logpanel = GameObject.Find("LogIn");
        logslide = logpanel.GetComponent<SlideController>();
        #endregion

        logbutton = GameObject.Find("LogInButton");

        //Create Empty Player Profile
        PlayerProfile = new LocalPlayer();

    }

    void Start()
    {
        
        plate.GetComponent<Text>().text = "BlahBlah";

        

    }

    //TODO Add disconnect method when players exit the lobby early
    public void ConnectToLobby()
    {
        //Make Connection to Server and Load Lobby;
        NetworkManager.networkInstance.socketManager.Connect(Connected);

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

        //plate.GetComponent<Text>().text = PlayerProfile.Name;

        
        logbutton.SetActive(false);


        MainPlayer.email = ld.data.email;


        mainslide.SlideInFlag();
        logslide.SlideOutFlag();


        Debug.Log("result is " + ld.data.name);

    }

    private void PopulateNetworkPlayers()
    {
        Debug.Log("Player Data Hit");

        foreach (PlayerData playerData in NetworkManager.NetworkInstance.socketManager.players)
        {
            if (playerData.name != null)
            {
                GameObject playerShip = (GameObject)Instantiate(Resources.Load("Prefabs/Player"));
                Player newNetworkPlayer = playerShip.GetComponent<Player>();
                players[playerData.id] = newNetworkPlayer;
            }
        }

        //NetworkManager.NetworkInstance.socketManager.OnReadyUp();
    }


    public void Connected()
    {
        //yield return null;

        Flag = true;
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
