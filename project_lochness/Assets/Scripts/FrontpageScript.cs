using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrontpageScript : MonoBehaviour
{
    public static int noOfPosts = 0;
    public Button[] children;

    void Start()
    {
        children = GetComponentsInChildren<Button>();
        InvokeRepeating("CheckNotifs", 2.0f, 3f);

    }

    void CheckNotifs()
    {
        if (noOfPosts > 4)
        {
            noOfPosts = 4;
        }


        foreach (Button element in children)
        {
            element.gameObject.SetActive(false);
        }

        for (int i = 0; i < noOfPosts; i++)
        {
            children[i].gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerScript.clout -= 0.0003f * noOfPosts;

    }
}
