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
        // UnityEditor.EditorApplication.isPlaying = false; // �׽�Ʈȯ�濡������
        Application.Quit(); // ����Ͽ��� ����
    }

    public void ChangeStage()
    {
        buttonSound.Play();
        GameManager.instance.stageName = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text; // ���� ������ ��ư�� �ؽ�Ʈ�� �޾ƿ�
    }

    public void SceneChange()
    {
        buttonSound.Play();
        GameManager.instance.SceneChange();
    }
}
