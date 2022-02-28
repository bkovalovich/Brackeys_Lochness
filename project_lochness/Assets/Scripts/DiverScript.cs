using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum DiverState {
    WalkingToEnter,
    Jumping,
    LookingforPlayer,
    EscapingPlayer,
    Done,
}

public class DiverScript : MonoBehaviour
{
    private DiverState diverState = DiverState.WalkingToEnter;
    public float movementSpeed;
    public float walkTime;
    private float currentWalkTime = 0f;

    public float jumpSpeed;
    public float gravity;
    public float jumpTime;
    private float currentJumpTime;

    public bool playerNearby = false;

    public float actionTimer;
    private float currentActionTimer;
    private float currentMethod;
    private int maxAmountofMethods = 5;



    void Start() {

    }

    void IdlingAround() {
        if (currentActionTimer >= actionTimer) {
            currentActionTimer = 0;
            currentMethod = Random.Range(0,maxAmountofMethods);
        } else {
            currentActionTimer += Time.deltaTime;
            switch (currentMethod) {
                case 0:
                    transform.position -= transform.right * 1f * Time.deltaTime;
                    transform.position += transform.up * 0.5f * Time.deltaTime;
                    break;
                case 1:
                    transform.position -= transform.right * 1f * Time.deltaTime;
                    transform.position -= transform.up * 0.5f * Time.deltaTime;
                    break;
                case 2:
                    transform.position -= transform.right * 1f * Time.deltaTime;
                    break;
                default:
                    transform.position -= transform.up * 0.5f * Time.deltaTime;
                    break;
            }
        }

    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            playerNearby = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        switch (diverState) {
            case DiverState.WalkingToEnter:
                if(currentWalkTime < walkTime) {
                    currentWalkTime += Time.deltaTime;
                    transform.position -= transform.right * movementSpeed * Time.deltaTime;
                } else {
                    diverState = DiverState.Jumping;
                }
                break;
            case DiverState.Jumping:
                if(currentJumpTime < jumpTime) {
                    currentJumpTime += Time.deltaTime;
                    transform.position += transform.up * jumpSpeed * Time.deltaTime;
                    jumpSpeed -= gravity;
                } else {
                    diverState = DiverState.LookingforPlayer;
                }
                break;
            case DiverState.LookingforPlayer:
                if (playerNearby) {
                    diverState = DiverState.EscapingPlayer;
                } else {
                    IdlingAround();
                 }
                break;
            case DiverState.EscapingPlayer:
                FrontpageScript.noOfPosts++;
                diverState = DiverState.Done;
                break;
            case DiverState.Done:
                transform.position += transform.up * 4f * Time.deltaTime;
                break; 

        }

    }
}
