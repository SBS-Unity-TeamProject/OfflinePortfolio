using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{

    public GameObject optionsPanel;  

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
