using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideController : MonoBehaviour {

    public Transform TargetPanel;
    public Transform HomeLocation;
    private Vector3 Home;
    private float time;
    private Vector3 target;



    // Use this for initialization
    void Start () {

        Home = transform.position;
        time = 1F;

    }
	
	// Update is called once per frame
	void Update ()
    {

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
        this.Target = TargetPanel.position;
    }

    public void SlideOutFlag()
    {
        //this.Target = HomeLocation.position;
        this.Target = Home;
    }
}
