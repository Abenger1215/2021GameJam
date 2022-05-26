using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{
    public Text missionText;
    public Text deliveryText;
    public string[] missionArray = new string[5];
    public GameObject[] missionTriggerArray = new GameObject[4];
    public int deliveryCount;
    public bool deliveryComplete;

    // Start is called before the first frame update
    void Start()
    {
        deliveryComplete = false;
        missionArray[0] = "1. 탐사수 배달하기";
        missionArray[1] = "2. 퇴근하기";
        missionArray[2] = "3. 선물사기";
        missionArray[3] = "4. 약속장소로 가기";
        missionArray[4] = "메리 크리스마스!";
    }

    public void MissionChange()
    {
        GameManager.instance.missionNumber++;
        deliveryComplete = false;
        missionText.text = missionArray[GameManager.instance.missionNumber];
        missionTriggerArray[GameManager.instance.missionNumber].transform.localScale = Vector3.one;
        missionTriggerArray[GameManager.instance.missionNumber].GetComponent<BoxCollider>().size = Vector3.one;
        Debug.Log("MissionChanged!" + GameManager.instance.missionNumber);
    }
}
