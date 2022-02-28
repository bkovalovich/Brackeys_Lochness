using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthScript : MonoBehaviour {
    public bool playerInDepth;

    public bool PlayerInDepth {
        get { return playerInDepth; }
    }

    public void OnTriggerstay2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            playerInDepth = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision) {
        playerInDepth = false;
    }

    }
