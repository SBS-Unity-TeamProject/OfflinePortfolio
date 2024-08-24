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
