using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float movementSpeed;
    public static float health = 10f;
    public static float hunger = 10f;
    public static float clout = 10f;

    void Start()
    {
        
    }

    void Movement() {

        if (Input.GetKey("w") && transform.position.y < 3f) { //UP
            transform.position += transform.up * movementSpeed;
        }
        
        if (Input.GetKey("s") && transform.position.y > -4.4f) { //DOWN
            transform.position -= transform.up * movementSpeed;
        }
        if (Input.GetKey("a") && transform.position.x > -8.2f) { //LEFT
            transform.position -= transform.right * movementSpeed;
        }
        if (Input.GetKey("d") && transform.position.x < 7.5f) { //RIGHT
            transform.position += transform.right * movementSpeed;
        }
    }

    void DebugPrints() {
        //Debug.Log($"health: {health}");
        Debug.Log($"playerpos: {transform.position}");
        //Debug.Log($"hunger: {hunger}");
        //Debug.Log($"clout: {clout}");
    }

    //Called by update to reduce hunger and eventually health
    void IncrementTimers() {
        if (health <= 0 || clout <= 0) {
            Destroy(gameObject);
        }

        if (hunger <= 0) {
            health -= 0.001f;
        } else {
            hunger -= 0.00001f;
        }
    }

    //Collider, gives health and 
    public void OnTriggerEnter2D(Collider2D collision) {
        switch (collision.gameObject.tag) {
            case "LessTastyFish":
                hunger += 0.2f;
                break;
            case "TastyFish":
                hunger += 5f;
                break;
            default:
                break;
        }
        }

        void Update() {
        DebugPrints();
        Movement();
        IncrementTimers();
    }
}
