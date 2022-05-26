using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionController : MonoBehaviour
{
    int collisionCount = 1;
    public GameObject player;
    public GameObject MissionManager;
    MissionManager Mm;

    // Start is called before the first frame update
    void Start()
    {
        Mm = MissionManager.GetComponent<MissionManager>();
        GameManager.instance.labCount = 0;
        gameObject.transform.localScale = Vector3.zero;
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject == player && collisionCount == 1)
        {
            collisionCount--;
            if (GameManager.instance.missionNumber == 0 && Mm.deliveryComplete)
            {
                Destroy(gameObject);
                Mm.MissionChange();
            }
            else if(GameManager.instance.missionNumber == 1 || GameManager.instance.missionNumber == 2)
            {
                Destroy(gameObject);
                Mm.MissionChange();
            }
            else if (GameManager.instance.missionNumber == 3)
            {
                Destroy(gameObject);
                GameManager.instance.isWin = true;
                GameManager.instance.isPlaying = false;
            }
        }
            
        if(collision.gameObject == player && Mm.deliveryComplete && collisionCount == 1)
        {
            collisionCount--;
            gameObject.transform.localScale = Vector3.zero;
            Mm.MissionChange();
        }
    }

}
