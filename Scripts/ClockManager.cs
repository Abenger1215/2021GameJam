using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockManager : MonoBehaviour
{
    public Text TimerText;
    public float startTime;
    public float limitTime = 300;
    public float time = GameManager.instance.time;
    public bool timerStart;

    // Start is called before the first frame update
    void Start()
    {
        time = limitTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (timerStart)
        {
            time = limitTime - Time.time + startTime;
            if((time % 1).ToString().Length > 2)
            {
                TimerText.text = ((int)time / 60 % 60).ToString() + ":" + ((int)time % 60).ToString() + ":" + (time % 1).ToString().Substring(2, 2);
            }
        }
        
        if(time < 0)
        {
            GameManager.instance.isLoose = true;
            GameManager.instance.isPlaying = false;
            timerStart = false;
        }
    }
}
