using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    public MonoBehaviour controller;

    public void SetControllerToFreeRoam() {
        Destroy(controller);
        controller = gameObject.AddComponent<FreeRoamController>() as FreeRoamController;
    }

    public void SetControllerToRevolution() {
        Destroy(controller);
        controller = gameObject.AddComponent<RevolutionController>() as RevolutionController;
    }
}
