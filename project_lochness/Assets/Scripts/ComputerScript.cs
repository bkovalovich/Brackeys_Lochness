using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScript : MonoBehaviour
{
    [SerializeField] public GameObject interactionPrefab;

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                 interactionPrefab.gameObject.SetActive(true);
                break;

        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                interactionPrefab.gameObject.SetActive(false);
                break;

        }
    }


}
