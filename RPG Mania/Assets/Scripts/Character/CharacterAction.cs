public class CharacterAction
{
    public delegate void ActionDelegate(CharacterInfo target);

    public string Name { get; private set; }
    public ActionDelegate Action { get; private set; }

    public CharacterAction(string name, ActionDelegate action)
    {
        Name = name;
        Action = action;
    }
}
