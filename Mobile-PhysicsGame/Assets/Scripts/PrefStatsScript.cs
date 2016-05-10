using UnityEngine;
using System.Collections;

public static class PrefStatsScript {

    public static int PipLevel1;
    public static int PipLevel2;
    public static int PipLevel3;
    public static int PipLevel4;
    public static int PipLevel5;
    public static int PipLevel6;

    // Use this for initialization
    static void Start () {
        //SetPlayerPrefs();
	}

    public static void SetPlayerPrefs()
    {
        if (!PlayerPrefs.HasKey("PipLevel1"))
        {
            PlayerPrefs.SetInt("PipLevel1", 0);
            PlayerPrefs.SetInt("PipLevel2", 0);
            PlayerPrefs.SetInt("PipLevel3", 0);
            PlayerPrefs.SetInt("PipLevel4", 0);
            PlayerPrefs.SetInt("PipLevel5", 0);
            PlayerPrefs.SetInt("PipLevel6", 0);
        }
        PipLevel1 = PlayerPrefs.GetInt("PipLevel1");
        PipLevel2 = PlayerPrefs.GetInt("PipLevel2");
        PipLevel3 = PlayerPrefs.GetInt("PipLevel3");
        PipLevel4 = PlayerPrefs.GetInt("PipLevel4");
        PipLevel5 = PlayerPrefs.GetInt("PipLevel5");
        PipLevel6 = PlayerPrefs.GetInt("PipLevel6");
    }

    public static void checkMax(int currentLevel, int stars)
    {
        Debug.Log("max to check" + currentLevel);
        switch(currentLevel)
        {
            case 1:
                if (PlayerPrefs.GetInt("PipLevel1") < stars)
                    PlayerPrefs.SetInt("PipLevel1", stars);
                break;
            case 2:
                if (PlayerPrefs.GetInt("PipLevel2") < stars)
                    PlayerPrefs.SetInt("PipLevel2", stars);
                break;
            case 3:
                if (PlayerPrefs.GetInt("PipLevel3") < stars)
                    PlayerPrefs.SetInt("PipLevel3", stars);
                break;
            case 4:
                if (PlayerPrefs.GetInt("PipLevel4") < stars)
                    PlayerPrefs.SetInt("PipLevel4", stars);
                break;
            case 5:
                if (PlayerPrefs.GetInt("PipLevel5") < stars)
                    PlayerPrefs.SetInt("PipLevel5", stars);
                break;
            case 6:
                if (PlayerPrefs.GetInt("PipLevel6") < stars)
                    PlayerPrefs.SetInt("PipLevel6", stars);
                break;
            default:
                break;
        }
    }
}
