using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public GameObject optionsPanel;
    [SerializeField]
    GameObject win, lose;
    Damageable damageable;

    private void Awake()
    {
        win.SetActive(true);
        lose.SetActive(false);
        if (damageable.playerDeath)
        {
            lose.SetActive(true);
        }
        else if (!damageable.playerDeath)
        {
            win.SetActive(true);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("NoNameGrave");
    }

    public void QuitGame()
    {
        //����Ƽ�󿡼� ��������
        EditorApplication.isPlaying = false;

        //���߿� ���ø����̼ǿ����� �������� (�ڵ��ᱺ����)
        // Application.Quit();
    }

    public void ToggleOptionsPanel()
    {

        optionsPanel.SetActive(!optionsPanel.activeSelf);
    }
}
