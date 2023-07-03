using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
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

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy.GetComponent<CharacterInfo>());
    }

    private void Awake() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}