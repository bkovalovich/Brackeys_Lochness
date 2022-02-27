using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkScript : MonoBehaviour
{
    public float swimSpeed;
    public GameObject player;
    public PlayerScript playerScript;
    public float strength;
    public DepthScript depthScript;
    public GameObject depth;
    public float bottom;
    public float top;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private int health = 2;

    void Start()
    { 
        depthScript = depth.GetComponent<DepthScript>();
        playerScript = player.GetComponent<PlayerScript>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if(depthScript.PlayerInDepth == true)//check if player is in depth and moves
        {
            Debug.Log("depth");
            if (player.transform.position.y > transform.position.y)//follow up
            {
                rb.velocity = new Vector2(rb.velocity.x, 1 * swimSpeed);
            }
            else if (player.transform.position.y < transform.position.y)//follow down
            {
                rb.velocity = new Vector2(rb.velocity.x, -1 * swimSpeed);
            }
            if(player.transform.position.x > transform.position.x)//follow right
            {
                sr.flipX = false;
                LateralMove();
            }
            else if(player.transform.position.x < transform.position.x)//follow left
            {
                sr.flipX = true;
                LateralMove();
            }
            

        }
        else//if player not in depth continue moving left or right
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            LateralMove();
        }
        //clamping position to bottom depth
        Vector2 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, bottom, top);
        transform.position = clampedPosition;
    }
    public void OnTriggerEnter2D(Collider2D col)//attacks player
    {
        if (col.gameObject.tag == "Player")
        {
            playerScript.Damage(strength);
        }
    }
    void LateralMove()//moves left and right according to the direction of the sprite
    {
        if (!sr.flipX)
        {
            rb.velocity = new Vector2(1 * swimSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-1 * swimSpeed, rb.velocity.y);
        }
    }
    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
            
    }
}
