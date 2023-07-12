using System.Collections.Generic;
using UnityEngine;

public class ActionList
{
    public static ActionList Instance { get; private set; }
    private IDictionary<string, CharacterAction> actionList;
    private IDictionary<string, CharacterAction> specialList;

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

        else return new CharacterAction("Null", 0, EmptyAction);
    }

    public CharacterAction GetSpecialAction(string key)
    {
        if (specialList.ContainsKey(key)) return specialList[key];

        else return new CharacterAction("Null", 0, EmptyAction);
    }

    private void FillDictionary()
    {
        actionList = new Dictionary<string, CharacterAction>()
        {
            {"base", new CharacterAction("Base Attack", 1, BaseAttack)},
            {"heavy", new CharacterAction("Heavy Attack", 2, HeavyAttack)},
            
        };

        specialList = new Dictionary<string, CharacterAction>()
        {
            {"health drain", new CharacterAction("Health Drain", 5, HealthDrainSpecial)},
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

    public void HealthDrainSpecial(CharacterInfo self, CharacterInfo target)
    {
        int damage = self.attack - target.defense;
        if (damage < 0) damage = 0;

        target.health -= damage;
        if (target.health < 0) target.health = 0;

        self.health += damage/2;
    }
}