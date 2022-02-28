using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResponseScript : MonoBehaviour
{
    public int clout;
    public Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(TaskOnClick);

    }
    void TaskOnClick()
    {
        PlayerScript.clout += clout;
        Destroy(transform.gameObject.GetComponentInParent<Canvas>().gameObject);

        // Instantiate(interactionPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));

    }

}
