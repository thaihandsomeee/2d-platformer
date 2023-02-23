using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject NewPlayer;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        SoundManager.Instance.PlayMouseClickedSound();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        SoundManager.Instance.PlayBMGSound();
        NewPlayer.GetComponent<PlayerMovement>().enabled = true;
    }

    public void Pause()
    {
        SoundManager.Instance.PlayMouseClickedSound();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        SoundManager.Instance.StopBMGSound();
        NewPlayer.GetComponent<PlayerMovement>().enabled = false;
        GameIsPaused = false;
    }

    public void SelectLevelMenu()
    {
        SoundManager.Instance.PlayMouseClickedSound();
        SceneManager.LoadScene("LevelSelection");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
