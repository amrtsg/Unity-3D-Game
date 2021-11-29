/*
MainMenu.cs
Author - Amr Ghoneim
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer mixer;

    void Start() {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void playGame() {
        SceneManager.LoadScene(2);
    }

    public void returnMainMenu() {
        SceneManager.LoadScene(0);
    }

    public void quitGame() {
        Debug.Log("Pressed Quit");
        Application.Quit();
    }

    public void setVolume(float vol) {
        mixer.SetFloat("volume", vol);
    }
}
