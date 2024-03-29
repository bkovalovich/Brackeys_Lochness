using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour {
    [SerializeField] public float speed;//Speed of bullet
    [SerializeField] public float lifetime;//How long the bullet lasts
    public Rigidbody2D rigid;//Accessing rigidbody in order to change position


    void Start() {
        rigid.velocity = transform.right * -speed;
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            Destroy(gameObject);
        }
    }

    //FixedUpdate()
    //Destroys object after an amount of time
    void FixedUpdate() {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0f) {
            Destroy(gameObject);
        }
    }

}
