using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    int count = 1;
    public AudioClip winMusic;
    public AudioClip loseMusic;
    public AudioSource audioSource;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isWin && count == 1)
        {
            audioSource.loop = false;
            count--;
            audioSource.PlayOneShot(winMusic);
        }
        else if (GameManager.instance.isLoose && count == 1)
        {
            audioSource.loop = false;
            count--;
            audioSource.PlayOneShot(loseMusic);
        }
    }
}
