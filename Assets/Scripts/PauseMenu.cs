/*
PauseMenu.cs
Author - Amr Ghoneim
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pauseMenuUI;
    public GameObject playerUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(isPaused) {
                resume();
            } else {
                pause();
            }
        }
    }

    public void resume() {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        playerUI.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void pause() {
        Cursor.lockState = CursorLockMode.Confined;
        pauseMenuUI.SetActive(true);
        playerUI.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void mainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void quitGame() {
        Debug.Log("Quitting game..");
        Application.Quit();
    }
}
