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
    public float maxRange;
    public float runChance;

    private float timer;
    private float maxTimer = 3;
    private float chance;
    private int lookedAround = 0;

    void Start()
    {
        depthScript = depth.GetComponent<DepthScript>();
        rb = GetComponent<Rigidbody2D>();
        chance = maxRange;
        timer = maxTimer;
    }
    // Update is called once per frame
    void Update()
    {
        lookOut = !Physics2D.Raycast(lookoutPoint.position, Vector2.down, .2f, ground);//checks if tourist is at cliff
        if(running == true)//tourist runs away
        {
            Run();
        }
        else
        {
            if(timer <= 0)
            {
                if (lookOut && depthScript.PlayerInDepth)//ckecks requirements for tourist running away
                {
                    chance = Random.Range(1f, maxRange);
                    if (chance <= runChance)
                    {
                        running = true;
                    }
                    else
                    {
                        timer = maxTimer;
                        lookedAround += 1;
                    }
                }    
            }
            if (lookOut)//stopping at cliff
            {
                rb.velocity = Vector2.zero;
                timer -= 1 * Time.deltaTime;
            }
            else//going up to the cliff
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
