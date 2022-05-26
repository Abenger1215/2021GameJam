using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string stageName;
    public bool isWin;
    public bool isLoose;
    public float time;
    public int labCount;
    public int missionNumber;

    //Booster
    public bool isBooster;

    //Blind
    public bool isBlind;

    //ReverseController
    public bool isReverseController;

    //for countdown and finish game detection
    public bool isPlaying;

    public static GameManager instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        ResetGameStatus();
    }

    public void ResetGameStatus()
    {
        isWin = false;
        isLoose = false;
        isBooster = false;
        isBlind = false;
        isPlaying = false;
        labCount = 0;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            isWin = true;
        }
    }
    public void SceneChange()
    {
        SceneManager.LoadScene(stageName);
    }


    #region item function

    public void BoosterOn()
    {
        isBooster = true;
        StartCoroutine(Booster());
    }

    public void BoosterOff()
    {
        isBooster = false;
    }

    IEnumerator Booster()
    {
        yield return new WaitForSecondsRealtime(3f);
        BoosterOff();
    }

    public void BlindOn()
    {
        isBlind = true;
        StartCoroutine(Blind());
    }

    public void BlindOff()
    {
        isBlind = false;
    }

    IEnumerator Blind()
    {
        yield return new WaitForSecondsRealtime(5f);
        BlindOff();
    }

    public void ReverseControllerOn()
    {
        isReverseController = true;
        StartCoroutine(ReverseController());
    }

    public void ReverseControllerOff()
    {
        isReverseController = false;
    }

    IEnumerator ReverseController()
    {
        yield return new WaitForSecondsRealtime(3f);
        ReverseControllerOff();
    }

    #endregion
}
