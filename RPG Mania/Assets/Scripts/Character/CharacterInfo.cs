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
    protected List<string> actionNames = new List<string>();

    protected List<CharacterAction> actions = new List<CharacterAction>();

    public void Start() {
        health = maxHealth;

        actionNames.Add("Base Attack");
        actionNames.Add("Heavy Attack");

        actions.Add(ActionList.GetInstance().actionList[actionNames[0]]);
        actions.Add(ActionList.GetInstance().actionList[actionNames[1]]);
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
        if (action.MpUse <= mp) action.Action(this, target);

        mp -= action.MpUse;
    }
}