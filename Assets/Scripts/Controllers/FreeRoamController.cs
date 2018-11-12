using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeRoamController : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    public int speed = 10;
    public int rotationSpeed = 200;

    public Joystick joystick;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        joystick = FindObjectOfType<Joystick>();
    }

    private void FixedUpdate()
    {
        var horizontalInput = -1 * (Input.GetAxis("Horizontal") + joystick.Horizontal);
        var verticalInput = Input.GetAxis("Vertical") + joystick.Vertical;


        float translattion = verticalInput * speed * Time.deltaTime + 0.001f;
        float rotation = horizontalInput * rotationSpeed * Time.deltaTime;
        transform.Translate(new Vector2(0, translattion));
        transform.Rotate(new Vector3(0, 0, rotation));
    }
}
