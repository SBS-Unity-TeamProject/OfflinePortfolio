using System.Collections;
using System.Collections.Generic;
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
        if(damageable)
        {
            if (damageable.playerDeath)
            {
                lose.SetActive(true);
            }
            else if (!damageable.playerDeath)
            {
                win.SetActive(true);
            }
        }

    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        //유니티상에서 게임종료
        Application.Quit();
    }

    public void ToggleOptionsPanel()
    {

        optionsPanel.SetActive(!optionsPanel.activeSelf);
    }
}
