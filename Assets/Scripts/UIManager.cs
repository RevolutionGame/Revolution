using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {


    public void slide() { }

    public void DisableBoolAnimator(Animator anim)
    {
        anim.SetBool("IsDisplayed", false);
    }

    public void EnableBoolAnimator(Animator anim)
    {
        anim.SetBool("IsDisplayed", true);
    }

    public void StartGame(int scene)
    {
        Application.LoadLevel(scene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
