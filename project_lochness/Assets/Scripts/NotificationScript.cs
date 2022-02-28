using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NotificationScript : MonoBehaviour
{
    [SerializeField] public GameObject interactionPrefab;

    
    public Button btn;

    void Start()
    {
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {

        Instantiate(interactionPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
        FrontpageScript.noOfPosts--;
}

}
