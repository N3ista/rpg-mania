using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterBattle : MonoBehaviour {
    [SerializeField] private Button battleButton;
    private int battleScene = 2;

    private void Awake() {
        battleButton.onClick.AddListener(Battle);
    }

    private void Battle() {
        SceneManager.LoadScene(battleScene);
    }
}