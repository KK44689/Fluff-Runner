using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIHandler : MonoBehaviour
{
    private SpawnManager spawnScript;

    public GameObject GameOverScreen;

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    void Start()
    {
        spawnScript =
            GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        GameOverScreen.SetActive(false);
    }

    void Update()
    {
        if (!spawnScript.isGameActive)
        {
            GameOverScreen.SetActive(true);
        }
    }
}
