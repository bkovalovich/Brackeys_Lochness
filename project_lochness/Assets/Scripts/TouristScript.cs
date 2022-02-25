using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouristScript : MonoBehaviour
{
    public float runSpeed;
    public float walkSpeed;
    public bool lookOut;
    public Transform lookoutPoint;
    public GameObject depth;
    public DepthScript depthScript;
    public LayerMask ground;
    public Rigidbody2D rb;
    public bool running = false;

    void Start()
    {
        depthScript = depth.GetComponent<DepthScript>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        lookOut = !Physics2D.Raycast(lookoutPoint.position, Vector2.down, .2f, ground);
        if(running == true)
        {
            Run();
        }
        else
        {
            if (lookOut && depthScript.PlayerInDepth)
            {
                running = true;
            }
            else if (lookOut)
            {
                rb.velocity = Vector2.zero;
            }
            else
            {
                rb.velocity = new Vector2(1 * walkSpeed, rb.velocity.y);
            }
        }
    }
    void Run()
    {
        rb.velocity = new Vector2(-1 * runSpeed, rb.velocity.y);
    }
}
