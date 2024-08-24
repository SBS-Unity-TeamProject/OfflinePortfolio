using System.Collections;
using System.Collections.Generic;
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

        Application.Quit();
    }

    public void ToggleOptionsPanel()
    {
       
        optionsPanel.SetActive(!optionsPanel.activeSelf);
    }
}
