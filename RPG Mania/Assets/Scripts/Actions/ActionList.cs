using System.Collections.Generic;
using UnityEngine;

public class ActionList
{
    public static ActionList Instance { get; private set; }
    public IDictionary<string, CharacterAction> actionList;

    private ActionList()
    {
        FillDictionary();
    }

    public static ActionList GetInstance()
    {
        if (Instance == null)
        {
            Instance = new ActionList();
        }

        return Instance;
    }

    private void FillDictionary()
    {
        actionList = new Dictionary<string, CharacterAction>()
        {
            {"Base Attack", new CharacterAction("Base Attack", 0, BaseAttack)},
            {"Heavy Attack", new CharacterAction("Heavy Attack", 0, HeavyAttack)},
        };
    }

    public void BaseAttack(CharacterInfo self, CharacterInfo target)
    {
        int damage = self.attack - target.defense;
        if (damage < 0) damage = 0;

        target.health -= damage;
        if (target.health < 0) target.health = 0;

        Debug.Log(damage);
    }

    public void HeavyAttack(CharacterInfo self, CharacterInfo target)
    {
        if (Random.Range(0,9) <= 3) {Debug.Log("Miss"); return;}

        int damage = self.attack * 2 - target.defense;

        if (damage < 0) damage = 0;

        target.health -= damage;
        if (target.health < 0) target.health = 0;

        Debug.Log(damage);
    }
}