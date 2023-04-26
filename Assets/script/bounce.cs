using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class bounce : MonoBehaviour
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

            // GameObject ball = GameObject.FindGameObjectWithTag("Ball");

            //GameObject newCircle = Instantiate(Circle_, new Vector3(0, maxY, 0), Quaternion.identity);
            // rb = newCircle.GetComponent<Rigidbody>();
            // Destroy(ball);

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
