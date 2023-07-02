using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {
    public KeyCode pauseKey = KeyCode.Escape;
    public Button resumeButton, quitButton;
    public GameObject pauseUI;
    private string mainMenuScene = "Main Menu";

    private void Start() {
    
        resumeButton.onClick.AddListener(Resume);
        quitButton.onClick.AddListener(Quit);

        Resume();
    }

    private void Update() {
        if (Input.GetKeyDown(pauseKey)) {
            if (Time.timeScale == 0f) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    private void Resume() {
        Time.timeScale = 1f; 
        pauseUI.SetActive(false);
    }

    private void Pause() {
        Time.timeScale = 0f; 
        pauseUI.SetActive(true);
    }

    private void Quit() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);
    }
}