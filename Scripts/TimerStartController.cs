using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerStartController : MonoBehaviour
{
    public GameObject ClockManager;
    ClockManager Cm;

    // Start is called before the first frame update
    void Start()
    {
        Cm = ClockManager.GetComponent<ClockManager>();
    }

    void StartTimer()
    {
        Cm.startTime = Time.time;
        Cm.time = 0;
        Cm.timerStart = true;
    }

}
