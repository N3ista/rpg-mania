using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class WorldManager : MonoBehaviour {
    [SerializeField] private Button battleButton;
    private GameObject gameController, player;
    private List<GameObject> enemies;
    private GameManager gameManager;
    private int battleScene = 2;

    private void Start() {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameManager = gameController.GetComponent<GameManager>();

        player = GameObject.FindGameObjectWithTag("Player");
        gameManager.player = player.GetComponent<PlayerInfo>();

        battleButton.onClick.AddListener(StartBattle);
    }

    private void StartBattle() {
        foreach (GameObject e in GameObject.FindGameObjectsWithTag("Enemy")) gameManager.enemies.Add(e.GetComponent<EnemyInfo>());

        SceneManager.LoadScene(battleScene);
    }
}