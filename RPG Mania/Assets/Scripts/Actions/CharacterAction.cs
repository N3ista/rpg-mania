public class CharacterAction
{
    public delegate void ActionDelegate(CharacterInfo self, CharacterInfo target);

    public string Name { get; private set; }
    public int MpUse { get; private set; }
    public ActionDelegate Action { get; private set; }

    public CharacterAction(string name, int mpUse, ActionDelegate action)
    {
        Name = name;
        MpUse = mpUse;
        Action = action;
    }
}
