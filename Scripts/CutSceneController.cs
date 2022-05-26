using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneController : MonoBehaviour
{
    public GameObject Cartoon;
    public GameObject ExplainText;
    //public AudioSource BGM;

    private void Start()
    {
        //StopMusic();
        Cartoon.SetActive(true);
        ExplainText.SetActive(false);
    }

    public void CartoonOff()
    {
        Cartoon.SetActive(false);
        ExplainText.SetActive(true);
    }

    public void PlayGame()
    {
        GameManager.instance.ResetGameStatus();
        SceneManager.LoadScene("Stage1");
    }

    //public void StopMusic()
    //{
    //    BGM.Stop();
    //}
}
