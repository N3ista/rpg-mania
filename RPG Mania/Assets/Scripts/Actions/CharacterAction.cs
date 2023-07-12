public class CharacterAction
{
    public delegate void ActionDelegate(CharacterInfo self, CharacterInfo target);

    public string Name { get; private set; }
    public int Cost { get; private set; }
    public bool Special { get; private set; }
    public ActionDelegate Action { get; private set; }

    public CharacterAction(string name, int cost, bool special, ActionDelegate action)
    {
        Name = name;
        Cost = cost;
        Special = special;
        Action = action;
    }
}
