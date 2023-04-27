using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class bounce : MonoBehaviour

// most of the code is taken from; Breakout | Simple Game Tutorial Unity 2D for Beginners (https://www.youtube.com/watch?v=jyXZ3RVe5as&ab_channel=SilverlyBee)
{
    public float minY = -5.5f;
    public GameObject Circle_;
    public float maxY = -1.3f;
    public float Velocity = 3;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        
        if (transform.position.y < minY)
        {
            transform.position = new Vector3(0, maxY, 0);
            rb.velocity = Vector3.zero;

           

        }
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, Velocity);
        Debug.Log(rb.velocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Pill"))
        { 
            Destroy(collision.gameObject);
        }
    }
}
