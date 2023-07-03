using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public CharacterInfo player;
    public List<CharacterInfo> enemies = new List<CharacterInfo>();

    public void SetPlayer(GameObject player)
    {
        this.player = player.GetComponent<CharacterInfo>();
    }

    public void AddEnemy(GameObject enemy)
    {
        enemies.Add(enemy.GetComponent<CharacterInfo>());
    }
    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
}