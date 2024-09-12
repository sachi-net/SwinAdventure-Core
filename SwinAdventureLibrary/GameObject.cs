namespace SwinAdventureLibrary;

public class GameObject : IdentifiableObject
{
    private string _name;
    private string _description;

    public string Name { get { return _name; } }

    public string ShortDescription { get { return $"{_name} ({FirstId})"; } }

    public virtual string FullDescription { get { return _description; } }

    public GameObject(string[] idents, string name, string description) : base(idents)
    {
        _name = name;
        _description = description;
    }
}
