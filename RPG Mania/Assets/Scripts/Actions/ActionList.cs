using System.Collections.Generic;
using UnityEngine;

public class ActionList
{
    public static ActionList Instance { get; private set; }
    private IDictionary<string, CharacterAction> actionList;

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

    public CharacterAction GetAction(string key)
    {
        if (actionList.ContainsKey(key)) return actionList[key];

        else return new CharacterAction("Null", 0, false, EmptyAction);
    }

    private void FillDictionary()
    {
        actionList = new Dictionary<string, CharacterAction>()
        {
            {"base", new CharacterAction("Base Attack", 1, false, BaseAttack)},
            {"heavy", new CharacterAction("Heavy Attack", 2, false, HeavyAttack)},
        };
    }

    public void EmptyAction(CharacterInfo self, CharacterInfo target)
    {
        Debug.Log("This action is null");
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
        int damage = (int)(self.attack * 1.5) - target.defense;

        if (damage < 0) damage = 0;

        target.health -= damage;
        if (target.health < 0) target.health = 0;

        Debug.Log(damage);
    }
}