using UnityEngine;

public class PlayerInfo : CharacterInfo {
    protected override void Start() {
        base.Start();

        specialKeys.Add("health drain");

        specialActions.Add(ActionList.GetInstance().GetSpecialAction(specialKeys[0]));
    }
}