using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleManager : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI pHealth, eHealth;
    [SerializeField] private GameObject eHealthContainer;
    private GameManager gameManager;

    private void Awake() {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    private void Start() {
        pHealth.text = "Player Health: " + gameManager.player.health;

        for (int i = 0; i < gameManager.enemies.Count; i++)
        {
            TextMeshProUGUI enemyHealthText = Instantiate(eHealth, eHealthContainer.transform);

            enemyHealthText.rectTransform.anchoredPosition = new Vector3(0, -i * 100);

            enemyHealthText.text = "Enemy Health: " + gameManager.enemies[i].health;
        }
    }
}