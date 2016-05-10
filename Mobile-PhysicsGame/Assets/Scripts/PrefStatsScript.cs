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
        //isSpells = true;
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
        if (PlayerPrefs.GetInt("PipLevel" + currentLevel) < stars)
            PlayerPrefs.SetInt("PipLevel" + currentLevel, stars);
    }
}
