using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {
    [SerializeField] private Button startButton, quitButton;
    private int nextScene = 1;

    private void Start() {
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void StartGame(){
        SceneManager.LoadScene(nextScene);
    }

    private void QuitGame(){
        Application.Quit();
    }
}