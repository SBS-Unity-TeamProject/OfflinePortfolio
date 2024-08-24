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
        
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        //유니티상에서 게임종료
        EditorApplication.isPlaying = false;

        //나중에 어플리케이션에서의 게임종료 (코드잠군상태)
       // Application.Quit();
    }

    public void ToggleOptionsPanel()
    {
       
        optionsPanel.SetActive(!optionsPanel.activeSelf);
    }
}
