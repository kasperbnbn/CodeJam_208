using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

// acceleration controll taken from "Unity Tutorial How Control And Move Gameobject With Accelerometer Or Gyroscope In Android Game." https://www.youtube.com/watch?v=wpSm2O2LIRM&ab_channel=AlexanderZotov
{
    public float speed;
    Rigidbody2D rb;
    float dirX;
    public float leftX = -12f;
    public float rightX = 12F;

    // Start is called before the first frame update
    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        dirX = Input.acceleration.x * speed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, leftX, rightX), transform.position.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    rb.velocity = new Vector2(dirX, 0f);
    }
}
