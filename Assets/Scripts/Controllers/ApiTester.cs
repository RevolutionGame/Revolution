using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApiTester : MonoBehaviour {

    ApiManager apiManager = new ApiManager();

    // Use this for initialization
    void Start () {

        StartCoroutine(login());

       
    }


    IEnumerator login(){

        string email = "cs9stephen@gmail2.com";
        string pass = "showmetheway";

        CoroutineWithData cd = new CoroutineWithData(this, apiManager.LoginUser(email, pass));
        yield return cd.coroutine;
        LoginData ld = (LoginData)cd.result;

        Debug.Log("result is " + ld.data.name);


    }

    // Update is called once per frame
    void Update () {
		
	}
}
