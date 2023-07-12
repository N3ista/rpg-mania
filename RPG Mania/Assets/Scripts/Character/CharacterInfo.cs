using UnityEngine;
using System.Collections.Generic;

public class CharacterInfo : MonoBehaviour {
    public string characterName = "";
    public int maxHealth;
    public int health;
    public int combo;
    public int stamina;
    public int attack;
    public int defense;
    public int speed;
    protected List<string> actionKeys = new List<string>();

    protected List<CharacterAction> actions = new List<CharacterAction>();

    public void Start() {
        health = maxHealth;

        actionKeys.Add("base");
        actionKeys.Add("heavy");

        actions.Add(ActionList.GetInstance().GetAction(actionKeys[0]));
        actions.Add(ActionList.GetInstance().GetAction(actionKeys[1]));
    }

    public CharacterAction GetAction(int i)
    {
        if (i < actions.Count) return actions[i];

        else return actions[0];

    }

    public int CountActions()
    {
        return actions.Count;
    }

    public void DoAction(CharacterAction action, CharacterInfo target)
    {
        if (action.Cost <= combo && !action.Special)
        {
            action.Action(this, target);
        }
    }

    public void DoSpecialAction(CharacterAction action, CharacterInfo target)
    {
        if (action.Cost <= stamina && action.Special) 
        {
            action.Action(this, target);

            stamina -= action.Cost;
        }
    }
}