using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform TargetPanel;
    public Transform HomeLocation;
    private float time;
    private bool SlideIn, SlideOut;



    // Use this for initialization
    void Start () {

        //HomeLocation = transform.position;
        time = 2F;
        SlideIn = SlideOut = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (SlideIn)
        {
            StartCoroutine(MoveInPosition(transform,TargetPanel.position, time));
        }

        if (SlideOut)
        {
            StartCoroutine(MoveOutPosition(transform, HomeLocation.position, time));
        }

    }

    public IEnumerator MoveInPosition(Transform transform, Vector3 go, float timeToMove)
    {
        RectTransform rt = GetComponent<RectTransform>();

        float wide = rt.rect.width;
        var currentPos = transform.position;
        var target = currentPos + new Vector3(wide/transform.localScale.x, 0, 0);

        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, go, t);
            yield return null;

        }
        SlideIn = false;
    }

    public IEnumerator MoveOutPosition(Transform transform, Vector3 go, float timeToMove)
    {
        RectTransform rt = GetComponent<RectTransform>();

        float wide = rt.rect.width;
        var currentPos = transform.position;
        var target = currentPos + new Vector3(wide / transform.localScale.x, 0, 0);

        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, go, t);
            yield return null;

        }
        SlideOut = false;
       
    }

    public void SlideInFlag()
    {
        SlideIn = !SlideIn;

    }

    public void SlideOutFlag()
    {
        SlideOut = !SlideOut;

    }
}
