using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    int collisionCount = 1;
    public GameObject player;
    public GameObject itembox;
    public ParticleSystem particle;
    public AudioSource sound;
    public float turnSpeed = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector3.one, turnSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == player && collisionCount == 1)
        {
            collisionCount--;
            itembox.transform.localScale = Vector3.zero; // 사라지는 효과
            particle.Play();
            sound.Play();
            print("아이템획득");
            int randomNum = Random.Range(0, 3);
            switch (randomNum)
            {
                case 0:
                    GameManager.instance.BoosterOn();
                    Debug.Log("BoosterItem");
                    break;
                case 1:
                    GameManager.instance.ReverseControllerOn();
                    Debug.Log("ReverseControllerItem");
                    break;
                case 2:
                    GameManager.instance.BlindOn();
                    Debug.Log("BlindItem");
                    break;
            }
            StartCoroutine(ItemRespawn());
        }
    }

    IEnumerator ItemRespawn()
    {
        yield return new WaitForSecondsRealtime(5f);
        print("아이템리스폰");
        itembox.transform.localScale = Vector3.one; // respawn
        collisionCount = 1;
    }
}