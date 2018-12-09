using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Transform playerTransform;
    public int depth = 10;

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void LateUpdate () {
        if (playerTransform != null)
        {
            transform.position = playerTransform.position + new Vector3(0, 0, depth);
            //transform.rotation = playerTransform.rotation.normalized;
        }
        else
        {
            Debug.Log("This is empty");
        }
    }

    public void setTarget(Transform target)
    {
        playerTransform = target;
    }
}
