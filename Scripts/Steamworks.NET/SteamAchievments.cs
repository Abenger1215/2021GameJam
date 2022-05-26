using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class SteamAchievments : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SteamUserStats.ResetAllStats(true);
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (!SteamManager.Initialized)
        {
            Debug.Log("Init");
            return;
        }
        if (GameManager.instance.isWin)
        {
            SteamUserStats.SetAchievement("ACH_WIN_ONE_GAME");
            SteamUserStats.StoreStats();
            Debug.Log("Achieve");
            return;
        }
        //SteamUserStats.ResetAllStats(true);
    }
}
