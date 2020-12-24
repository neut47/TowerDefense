using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameEnded;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;
    

    private void Start()
    {
        gameEnded = false;
    }

    void Update()
    {
        if (gameEnded)
            return;

        if (Input.GetKeyDown("e"))
            EndGame();

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        gameEnded = true;
        completeLevelUI.SetActive(true);
    }
}
