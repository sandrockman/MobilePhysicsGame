using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSetupScript : MonoBehaviour {

    public GameObject buttonL1;
    public GameObject buttonL2;
    public GameObject buttonL3;
    public GameObject buttonL4;
    public GameObject buttonL5;
    public GameObject buttonL6;



    // Use this for initialization
    void Start () {
        if (PrefStatsScript.PipLevel1 == 0)
        {
            //still needs to be available.
        }
        else
        {
            buttonL1.GetComponent<Text>().text = "Level 1:\nStars-" + PrefStatsScript.PipLevel1;
        }
        //level 2 
        if (PrefStatsScript.PipLevel2 == 0)
        {
            buttonL2.SetActive(false);
        }
        else
        {
            buttonL2.GetComponent<Text>().text = "Level 2:\nStars-" + PrefStatsScript.PipLevel2;
        }
        //level 3
        if (PrefStatsScript.PipLevel3 == 0)
        {
            buttonL3.SetActive(false);
        }
        else
        {
            buttonL3.GetComponent<Text>().text = "Level 3:\nStars-" + PrefStatsScript.PipLevel3;
        }
        //level 4
        if (PrefStatsScript.PipLevel4 == 0)
        {
            buttonL4.SetActive(false);
        }
        else
        {
            buttonL4.GetComponent<Text>().text = "Level 4:\nStars-" + PrefStatsScript.PipLevel4;
        }
        //level 5
        if (PrefStatsScript.PipLevel5 == 0)
        {
            buttonL5.SetActive(false);
        }
        else
        {
            buttonL5.GetComponent<Text>().text = "Level 5:\nStars-" + PrefStatsScript.PipLevel5;
        }
        //level 6
        if (PrefStatsScript.PipLevel2 == 0)
        {
            buttonL6.SetActive(false);
        }
        else
        {
            buttonL6.GetComponent<Text>().text = "Level 6:\nStars-" + PrefStatsScript.PipLevel6;
        }


    }

    // Update is called once per frame
    void Update () {
	
	}
}
