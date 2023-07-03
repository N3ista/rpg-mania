using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndBattle : MonoBehaviour {
    [SerializeField] private Button returnButton;
    private int worldScene = 1;

    private void Awake() {
        returnButton.onClick.AddListener(Return);
    }

    private void Return(){
        SceneManager.LoadScene(worldScene);
    }

}