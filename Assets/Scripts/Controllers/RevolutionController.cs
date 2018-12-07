using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolutionController : MonoBehaviour {

    private Vector3 centerPoint;
    private readonly int radius = 8;
    public int speed = 1;

    private void FixedUpdate()
    {
        var translate = Input.GetAxis("Horizontal") * speed;
        transform.RotateAround(Vector3.zero, Vector3.forward, translate);
    }

    public void RemoveSelf()
    {
        Destroy(this);
    }
}

