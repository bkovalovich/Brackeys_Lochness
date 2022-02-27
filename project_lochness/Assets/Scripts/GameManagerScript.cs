using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] public Text playerHealthText;
    [SerializeField] public Text playerHungerText;
    [SerializeField] public Text playerCloutText;

    [SerializeField] public GameObject lessTastyFishPrefab;
    [SerializeField] public float lessTastyFishRate;

    [SerializeField] public GameObject tastyFishPrefab;
    [SerializeField] public float tastyFishRate;

    [SerializeField] public GameObject diverPrefab;
    [SerializeField] public float diverRate;


    void Start() {
        InvokeRepeating("GenerateLessTastyFish", 2f, lessTastyFishRate);
        InvokeRepeating("GenerateTastyFish", 5f, tastyFishRate);
        InvokeRepeating("GenerateDivers", 3f, tastyFishRate);

    }

    void GenerateLessTastyFish() {
          Instantiate(lessTastyFishPrefab, new Vector3(8f, 0f, 0f), new Quaternion(0, 0, 0, 0));
    }

    void GenerateTastyFish() {
        Instantiate(tastyFishPrefab, new Vector3(8f, 2f, 0f), new Quaternion(0, 0, 0, 0));
    }

    void GenerateDivers() {
        Instantiate(diverPrefab, new Vector3(9.99f, 3.56f, 0f), new Quaternion(0, 0, 0, 0));

    }

    void Update()
    {      
        playerHealthText.text = "Health: " + PlayerScript.health.ToString();
        playerHungerText.text = "Hunger: " + PlayerScript.hunger.ToString();
        playerCloutText.text = "Clout: " + PlayerScript.clout.ToString();

    }
}
