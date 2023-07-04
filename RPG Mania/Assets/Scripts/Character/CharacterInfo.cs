using UnityEngine;
using System.Collections.Generic;

public class CharacterInfo : MonoBehaviour {
    public string characterName = "";
    public int maxHealth = 10;
    public int health;
    public int attack = 10;
    public int defense = 5;
    public int speed = 10;

    public List<CharacterAction> actions = new List<CharacterAction>();

    public void Start() {
        health = maxHealth;

        actions.Add(new CharacterAction("Base Attack", BaseAttack));
    }

    public CharacterAction GetAction(int i)
    {
        if (i < actions.Count) return actions[i];

        else return actions[0];

    }

    private void BaseAttack(CharacterInfo target)
    {
        int damage = attack - target.defense;
        if (damage < 0) damage = 0;

        target.health -= damage;
    }
}