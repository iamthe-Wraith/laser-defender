using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2f;

    ScoreKeeper scoreKeeper;

    public void LoadGame()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("Game");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoadScene("GameOver", sceneLoadDelay));
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Goodbye");
        Application.Quit();
    }

    private IEnumerator WaitAndLoadScene(string scene, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);        
    }
}
