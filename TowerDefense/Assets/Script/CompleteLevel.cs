using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    public string nextLevel;
    public int levelToUnlock;

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        SceneManager.LoadScene(nextLevel);
    }
}
