using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndBattle : MonoBehaviour {
    [SerializeField] private Button returnButton;
    [SerializeField] private BattleManager battleManager;
    private void Awake() {
        returnButton.onClick.AddListener(Return);
    }

    private void Return(){
        battleManager.EndBattle();
    }

}