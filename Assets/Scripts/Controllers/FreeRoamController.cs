using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeRoamController : MonoBehaviour
{
    public int rotationalSpeed = 200;
    public int speed = 10;

    private void FixedUpdate()
    {
        var horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * rotationalSpeed;
        var vertialInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(new Vector2(0, vertialInput));
        transform.Rotate(new Vector3(0, 0, -horizontalInput));
    }

    public void RemoveSelf()
    {
        Destroy(this);
    }
}
