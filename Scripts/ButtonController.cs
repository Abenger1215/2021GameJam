using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public AudioSource buttonSound;

    public void ChangeToCutScene()
    {
        buttonSound.Play();
        SceneManager.LoadScene("CutScene");
    }

    public void ChangeToSelectScene()
    {
        buttonSound.Play();
        SceneManager.LoadScene("StageSelectScene");
    }

    public void ChangeToMaineMenuScene()
    {
        buttonSound.Play();
        SceneManager.LoadScene("MainMenuScene");
    }

    public void ClickExit()
    {
        buttonSound.Play();
        // UnityEditor.EditorApplication.isPlaying = false; // 테스트환경에서종료
        Application.Quit(); // 모바일에서 종료
    }

    public void ChangeStage()
    {
        buttonSound.Play();
        GameManager.instance.stageName = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text; // 현재 선택한 버튼의 텍스트를 받아옴
    }

    public void SceneChange()
    {
        buttonSound.Play();
        GameManager.instance.SceneChange();
    }
}
