using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideController : MonoBehaviour {

    public Transform TargetPanel;
    public Transform HomeLocation;
    private Vector3 Home;
    public float time;
    private Vector3 target;

    private GameObject main;
    private SlideController slider;


    void Awake()
    {
        main = GameObject.Find("MainPanel");
        slider = main.GetComponent<SlideController>();
        
    }
        
    // Use this for initialization
     void Start ()
    {

        Home = HomeLocation.position;
        time = 1F;
    }

    public Vector3 Target
    {
        get { return target; }
        set
        {
            target = value;
            StopCoroutine("MoveInPosition");
            StartCoroutine(MoveInPosition(transform, target, time));
        }
    }

    public IEnumerator MoveInPosition(Transform transform, Vector3 target, float timeToMove)
    {

        var t = 0f;
        while (Vector3.Distance(transform.position, target) > .05f)
        {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(transform.position, target, t);
            yield return null;

        }

        StopCoroutine("MoveInPosition");

    }

    public void SlideInFlag()
    {
        Target = TargetPanel.position;
    }

    public void SlideOutFlag()
    {
        Target = Home;
        
    }

}
