using UnityEngine;

public class CharacterInfo : MonoBehaviour {
    public int maxHealth = 10;
    public int health;
    public int attack = 10;
    public int defense = 5;
    public int speed = 10;

    public void Start() {
        health = maxHealth;
    }
}