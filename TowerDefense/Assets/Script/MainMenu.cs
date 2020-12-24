using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LevelToLoad;

    public void Play()
    {
        SceneManager.LoadScene(LevelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
