﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class listcontrol : MonoBehaviour {


    protected ScrollRect scrollRect;
    protected RectTransform contentPanel;
    public Button item;

    // Use this for initialization
    void Start () {
        contentPanel = GetComponent<RectTransform>();

        Button GO = Instantiate(item, contentPanel.transform);
        GO = Instantiate(item, contentPanel.transform);
        GO = Instantiate(item, contentPanel.transform);
        GO = Instantiate(item, contentPanel.transform);
        GO = Instantiate(item, contentPanel.transform);
        GO = Instantiate(item, contentPanel.transform);
        GO = Instantiate(item, contentPanel.transform);
        GO = Instantiate(item, contentPanel.transform);
        GO = Instantiate(item, contentPanel.transform);

    }
	
	// Update is called once per frame
	void Update () {
		
	}



    public void SnapTo(RectTransform target)
    {
        Canvas.ForceUpdateCanvases();

        contentPanel.anchoredPosition =
            (Vector2)scrollRect.transform.InverseTransformPoint(contentPanel.position)
            - (Vector2)scrollRect.transform.InverseTransformPoint(target.position);
    }
}