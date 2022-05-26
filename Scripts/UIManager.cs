using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject winUI;
    public GameObject loseUI;
    public GameObject blindUI;
    public GameObject mapUI;

    void Start()
    {
        blindUI.SetActive(false);
        winUI.SetActive(false);
        loseUI.SetActive(false);
    }

    private void Update()
    {

        bool isBlind = GameManager.instance.isBlind;

        if (Input.GetKey(KeyCode.M))
        {
            mapUI.SetActive(true);
        }
        else
        {
            mapUI.SetActive(false);
        }

        if (GameManager.instance.isLoose)
        {
            loseUI.SetActive(true);
        }
        if (GameManager.instance.isWin)
        {
            winUI.SetActive(true);
        }

        if (isBlind)
        {
            blindUI.SetActive(true);
        }
        else
        {
            blindUI.SetActive(false);
        }

    }
}
