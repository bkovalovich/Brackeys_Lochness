using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftWoodScript : MonoBehaviour
{
    public float driftSpeed;
    public float riseSpeed;
    public float health;
    public float surface;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            rb.velocity = new Vector2(0, 1 * riseSpeed);
        }
        else
        {
            rb.velocity = new Vector2(1 * driftSpeed, 0);
        }
        Vector2 clampedRoof = transform.position;
        clampedRoof.y = Mathf.Clamp(clampedRoof.y, -5f, surface);
        transform.position = clampedRoof;
    }
    public void Damage(float damage)
    {
        Debug.Log("took damage");
        health -= damage;
    }
}
