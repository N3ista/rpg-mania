using System.Collections.Generic;
using UnityEngine;

public class ComboList
{
    public static ComboList Instance { get; private set; }
    private IDictionary<string, ComboAction> actionList;

    private ComboList()
    {
        FillDictionary();
    }

    public static ComboList GetInstance()
    {
        if (Instance == null)
        {
            Instance = new ComboList();
        }

        return Instance;
    }

    public ComboAction GetAction(string key)
    {
        if (actionList.ContainsKey(key)) return actionList[key];

        else return new ComboAction("Null", 0, EmptyAction);
    }


    private void FillDictionary()
    {
        actionList = new Dictionary<string, ComboAction>()
        {
            {"base", new ComboAction("Base Attack", 1, BaseAttack)},
            {"heavy", new ComboAction("Heavy Attack", 2, HeavyAttack)},
            
        };
    }

    public void EmptyAction(CharacterInfo self, CharacterInfo target)
    {
        Debug.Log("This action is null");
    }

    private void Attack(CharacterInfo self, CharacterInfo target)
    {
        int damage = self.attack - target.defense;
        if (damage < 0) damage = 0;

        target.health -= damage;
        if (target.health < 0) target.health = 0;

        if (self.activeSkill != null)
            self.activeSkill.Action(self, target, damage);

        Debug.Log(damage);
    }

    public void BaseAttack(CharacterInfo self, CharacterInfo target)
    {
        Attack(self, target);
    }

    public void HeavyAttack(CharacterInfo self, CharacterInfo target)
    {
        Attack(self, target);
    }
}