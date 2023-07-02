using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {
    [SerializeField] private KeyCode pauseKey = KeyCode.Escape;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private Button resumeButton, quitButton;
    private int mainMenuSceneIndex = 0;

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
        SceneManager.LoadScene(mainMenuSceneIndex);
    }
}