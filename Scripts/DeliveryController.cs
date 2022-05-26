using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryController : MonoBehaviour
{
    int collisionCount = 1;
    public GameObject player;
    public GameObject MissionManager;
    public AudioSource baedal;
    MissionManager Mm;

    // Start is called before the first frame update
    void Start()
    {
        Mm = MissionManager.GetComponent<MissionManager>();
        Mm.deliveryCount = 0;
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject == player && collisionCount == 1)
        {
            collisionCount--;
            gameObject.transform.localScale = Vector3.zero;
            Mm.deliveryCount++;
            Mm.deliveryText.text = "배달 진행도 " + Mm.deliveryCount.ToString() + " / 5";
            Debug.Log("현재 진행도 " + Mm.deliveryCount);
            if (Mm.deliveryCount == 5)
            {
                Mm.deliveryComplete = true;
                Mm.MissionChange();
                Mm.deliveryText.text = "배달완료!";
            }
            baedal.Play();
        }
    }

}
