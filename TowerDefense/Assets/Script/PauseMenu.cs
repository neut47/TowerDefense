using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    //pause menu
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }     
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if(ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Menu()
    {
        Toggle();
        SceneManager.LoadScene("MainMenu");
    }
    //bastan baslat
    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
