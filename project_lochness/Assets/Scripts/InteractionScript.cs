using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


public class InteractionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

            string negativePath = @"../project_lochness/Assets/Text/Negative.txt";
            string[] negativeLines = File.ReadAllLines(negativePath);

            string NnegativePath = @"../project_lochness/Assets/Text/Nnegative.txt";
            string[] NnegativeLines = File.ReadAllLines(NnegativePath);

            string PositivePath = @"../project_lochness/Assets/Text/Positive.txt";
            string[] PositiveLines = File.ReadAllLines(PositivePath);

            string PpositivePath = @"../project_lochness/Assets/Text/Ppositive.txt";
            string[] PpositiveLines = File.ReadAllLines(PpositivePath);

            string AtsPath = @"../project_lochness/Assets/Text/Ats.txt";
            string[] AtsLines = File.ReadAllLines(AtsPath);

            string TweetsPath = @"../project_lochness/Assets/Text/Tweets.txt";
            string[] TweetsLines = File.ReadAllLines(TweetsPath);

        Button[] children = GetComponentsInChildren<Button>();
        Text[] tweetText = GetComponentsInChildren<Text>();

        Debug.Log(children.Length);

        //Random.Range(-10.0f, 10.0f)

        GameObject.Find("Positive").GetComponentInChildren<Text>().text = PositiveLines[Random.Range(0, PositiveLines.Length)];
       // children[1].GetComponentInChildren<Text>().text = PositiveLines[Random.Range(0, PositiveLines.Length)];




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
