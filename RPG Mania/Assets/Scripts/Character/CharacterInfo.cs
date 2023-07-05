using UnityEngine;
using System.Collections.Generic;

public class CharacterInfo : MonoBehaviour {
    public string characterName = "";
    public int maxHealth;
    public int health;
    public int mp;
    public int attack;
    public int defense;
    public int speed;

    public List<CharacterAction> actions = new List<CharacterAction>();

    public void Start() {
        health = maxHealth;

        actions.Add(new CharacterAction("Base Attack", 0, BaseAttack));
        actions.Add(new CharacterAction("Heavy Attack", 0, HeavyAttack));
    }

    public CharacterAction GetAction(int i)
    {
        if (i < actions.Count) return actions[i];

        else return actions[0];

    }

    public void DoAction(CharacterAction action, CharacterInfo target)
    {
        action.Action(this, target);
        mp -= action.MpUse;
        if (mp < 0) mp = 0;
    }

    private void BaseAttack(CharacterInfo self, CharacterInfo target)
    {
        int damage = self.attack - target.defense;
        if (damage < 0) damage = 0;

        target.health -= damage;
        if (target.health < 0) target.health = 0;

        Debug.Log(damage);
    }

    private void HeavyAttack(CharacterInfo self, CharacterInfo target)
    {
        if (Random.Range(0,9) <= 3) {Debug.Log("Miss"); return;}

        int damage = self.attack * 2 - target.defense;

        if (damage < 0) damage = 0;

        target.health -= damage;
        if (target.health < 0) target.health = 0;

        Debug.Log(damage);
    }
}