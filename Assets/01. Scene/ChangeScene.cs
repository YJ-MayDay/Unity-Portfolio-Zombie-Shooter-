using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private PauseMenu pause;
    private void Start()
    {
        pause = GameObject.Find("Main Camera").GetComponent<PauseMenu>();
    }

    public void ChangeGameScene()
    {
        SceneManager.LoadScene("1.Play_Game");
    }

    public void ResumeGame()
    {
        pause.paused = false;
        pause. PauseUI.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("0.Main");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
