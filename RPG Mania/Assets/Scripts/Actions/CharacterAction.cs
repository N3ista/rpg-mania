public class CharacterAction
{
    public delegate void ActionDelegate(CharacterInfo self, CharacterInfo target);

    public string Name { get; private set; }
    public int Cost { get; private set; }
    public ActionDelegate Action { get; private set; }

    public CharacterAction(string name, int cost, ActionDelegate action)
    {
        Name = name;
        Cost = cost;
        Action = action;
    }
}
